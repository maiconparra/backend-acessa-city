using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}