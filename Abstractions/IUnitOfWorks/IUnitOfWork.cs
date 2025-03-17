using YaradiciEduAz.Abstractions.IRepositories;

namespace YaradiciEduAz.Abstractions.IUnitOfWorks
{
    public interface IUnitOfWork:IDisposable
    {
        public Task<int> SaveAsync();
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
