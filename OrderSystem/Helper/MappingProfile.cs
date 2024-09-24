using AutoMapper;
using OrderSystem.Dtos;
using Talabat.Rev.CoreLayer.Entites;

namespace OrderSystem.Helper
{
    public class MappingProfile:Profile
    {


        public MappingProfile()
        {
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItems,BasketItemsDto>().ReverseMap();
        }
    }
}
