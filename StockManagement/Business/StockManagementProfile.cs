using AutoMapper;
using StockManagement.Data.Entities;
using StockManagement.Models;

namespace StockManagement.Business
{
    public class StockManagementProfile : Profile
    {
        public StockManagementProfile()
        {
            CreateMap<ProductModel, Product>().ReverseMap();
        }
    }
}
