using AutoMapper;
using FirstWebDBApp.DTO;
using FirstWebDBApp.Models;

namespace FirstWebDBApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<CustomerInsertDTO, Customer>().ReverseMap();
            CreateMap<CustomerUpdateDTO, Customer>().ReverseMap();
            CreateMap<CustomerReadOnlDTO, Customer>().ReverseMap();
        }
    }
}
