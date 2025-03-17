using YaradiciEduAz.Abstractions.IRepositories.IEntityRepositories;
using YaradiciEduAz.Contexts;

namespace YaradiciEduAz.Implementations.Repositories.EntityRepositories
{
    public class CategoryRepository:GenericRepository<Entities.Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
