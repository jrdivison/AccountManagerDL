namespace AccountManager.Data.Core
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using AutoMapper;
    using System.Linq.Expressions;

    //Comunicarse con la capa de datos
    public abstract class DataServiceBase<TEntity, TId, TContext>
        where TId: IEquatable<TId>
        where TEntity : ModelBase<TId> //accept only classes
        where TContext : DbContext     //acept only DbContext class
    {
        protected DataServiceBase(IMapper mapper, TContext context)
        {
            Context = context;
            Mapper = mapper;
        }

        protected TContext Context { get; set; }
        protected IMapper Mapper { get; set; }

        public int AddOrUpdate<TDto> (TDto model)
        {
            TEntity entity = Mapper.Map<TEntity>(model);
            if (!BeforeAddOrUpdate(entity))
            {
                throw new Exception("Data validation error");
            }

            if (entity.IsNewModel())
            {
                Context.Add(entity);
            } else
            {
                TEntity originalEntity = Context.Find<TEntity>(entity.Id);
                originalEntity = Mapper.Map(model, originalEntity);
            }
            return Context.SaveChanges();
        }

        public virtual bool BeforeAddOrUpdate(TEntity entity)
        {
            return true;
        }
        //Data Transport Object = DTO
        public IQueryable<TDto> GetAll<TDto>()
        {
            DbSet<TEntity> table = Context.Set<TEntity>();
            return Mapper.ProjectTo<TDto>(table);
        }

        public IQueryable<TDto> GetAll<TDto>(Expression<Func<TEntity, bool>> filter)
        {
            DbSet<TEntity> table = Context.Set<TEntity>();
            return Mapper.ProjectTo<TDto>(table);
        }
    }
}
