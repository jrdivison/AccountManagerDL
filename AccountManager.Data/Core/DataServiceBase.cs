namespace AccountManager.Data.Core
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using AutoMapper;
    using System.Linq.Expressions;

    public abstract class DataServiceBase<TEntity, TContext>
        where TEntity : class       //accept only classes
        where TContext : DbContext  //acept only DbContext class
    {
        protected DataServiceBase(IMapper mapper, TContext context)
        {
            Context = context;
            Mapper = mapper;
        }

        protected TContext Context { get; set; }
        protected IMapper Mapper { get; set; }

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
