using StockManagement.Models;
using System.Collections.Generic;

namespace StockManagement.Business.IManager
{
    public interface IProductManager
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel GetById(int productId);
        bool IsProductInStock(int productId);
        void Delete(int productId);
        ProductModel AddToStock(ProductModel request);
        void UpdateItem(ProductModel request, int productId);
    }
}
