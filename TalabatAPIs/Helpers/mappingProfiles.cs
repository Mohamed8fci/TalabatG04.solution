using AutoMapper;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Identity;
using TalabatAPIs.Dtos;

namespace TalabatAPIs.Helpers
{
    public class mappingProfiles : Profile
    {
        public mappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());

            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
