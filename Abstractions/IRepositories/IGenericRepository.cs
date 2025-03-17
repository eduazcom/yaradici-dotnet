using Microsoft.EntityFrameworkCore;

namespace YaradiciEduAz.Abstractions.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<bool> Add(T entity);
        public IQueryable<T> GetAll();
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
        public Task<T> GetById(int id);
        DbSet<T> Table { get; }
    }
}
