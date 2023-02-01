using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames.Data.Models;
using ToysAndGames.DTO.ModelsDTO;

namespace ToysAndGames.DTO
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            //Products
            CreateMap<AddProductDTO, Product>();
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Companies.Name));

            //Companies
            CreateMap<AddCompanyDTO, Company>();
            CreateMap<Company, CompanyDTO>();
        }
    }
}
