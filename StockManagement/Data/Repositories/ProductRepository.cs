using StockManagement.Data.Entities;
using StockManagement.Data.IRepositories;

namespace StockManagement.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(StockManagementDbContext context)
            : base(context) { }
    }
}
