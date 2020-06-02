using AutoMapper;
using StockManagement.Business.IManager;
using StockManagement.Data.Entities;
using StockManagement.Data.IRepositories;
using StockManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace StockManagement.Business.Manager
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductModel AddToStock(ProductModel request)
        {
            var entity = _mapper.Map<Product>(request);

            var created = _productRepository.Create(entity);

            return _mapper.Map<ProductModel>(created);
        }

        public void Delete(int productId)
        {
            var entity = _productRepository.FindById(productId);

            _productRepository.Delete(entity);
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var products = _productRepository.GetAll().AsEnumerable();

            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public ProductModel GetById(int productId)
        {
            var product = _productRepository.FindById(productId);

            return _mapper.Map<ProductModel>(product);
        }

        public bool IsProductInStock(int productId)
        {
            return _productRepository.Exists(q => q.ProductId == productId);
        }

        public void UpdateItem(ProductModel request, int productId)
        {
            var entity = _productRepository.FindById(productId);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.AgeRestriction = request.AgeRestriction;
            entity.Company = request.Company;
            entity.Price = request.Price;

            _productRepository.Update(entity);
        }
    }
}
