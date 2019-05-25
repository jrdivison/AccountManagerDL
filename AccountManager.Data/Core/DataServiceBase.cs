using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountManager.Data.Core
{
    public abstract class DataServiceBase<TEntity, TId, TContext>
        where TId: IEquatable<TId>
        where TEntity: ModelBase<TId>
        where TContext: DbContext
    {
        public DataServiceBase(IMapper mapper, TContext context)
        {
            Context = context;
            Mapper = mapper;
        }

        protected TContext Context { get; set; }
        protected IMapper Mapper { get; set; }

        public int AddOrUpdate<TDto>(TDto model)
        {
            TEntity entity = Mapper.Map<TEntity>(model);
            if (!BeforeAddOrupdate(entity))
                throw new Exception("Error de validacion");

            if(entity.IsNewModel())
            {
                Context.Add(entity);
            }
            else
            {
                TEntity originalEntity = Context.Find<TEntity>(entity.Id);
                originalEntity = Mapper.Map(model, originalEntity);
            }

            return Context.SaveChanges();
        }

        public virtual bool BeforeAddOrupdate(TEntity entity)
        {
            return true;
        }

        public IQueryable<TDto> GetAll<TDto>()
        {
            DbSet<TEntity> table = Context.Set<TEntity>();
            return Mapper.ProjectTo<TDto>(table);
        }

        public IQueryable<TDto> GetAll<TDto>(Expression<Func<TEntity, bool>> filter)
        {
            DbSet<TEntity> table = Context.Set<TEntity>();
            return Mapper.ProjectTo<TDto>(table.Where(filter));
        }

        public void Delete(TId id)
        {
            DbSet<TEntity> table = Context.Set<TEntity>();
            TEntity entityDelete = table.Find(id);
            table.Remove(entityDelete);
            if (Context.ChangeTracker.HasChanges())
                Context.SaveChanges();
        }

        public TDto GetById<TDto>(TId id)
        {
            DbSet<TEntity> table = Context.Set<TEntity>();
            TEntity entity = table.Find(id);
            return Mapper.Map<TDto>(entity);
        }
    }
}
