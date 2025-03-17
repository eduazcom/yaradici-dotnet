using YaradiciEduAz.Abstractions.IRepositories;
using YaradiciEduAz.Abstractions.IUnitOfWorks;
using YaradiciEduAz.Contexts;
using YaradiciEduAz.Implementations.Repositories;

namespace YaradiciEduAz.Implementations.UnitOfWorks
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private Dictionary<Type, object> _repositories;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _repositories = new Dictionary<Type, object>();

        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
            }
            GenericRepository<TEntity> genericRepository = new GenericRepository<TEntity>(_appDbContext);
            _repositories.Add(typeof(TEntity), genericRepository);
            return genericRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
