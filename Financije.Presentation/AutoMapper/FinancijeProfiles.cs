using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Financije.Core.Entities;
using Financije.Presentation.Models.Financije;

namespace Financije.Presentation.AutoMapper
{
    public class FinancijeProfiles : Profile
    {

        public FinancijeProfiles()
        {
            CreateMap<Articles, ArticlePreviewModel>()
                .ForMember(dest => dest.ArticleId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DescriptionName, opt => opt.MapFrom(src => src.Description.DescriptionName));

            CreateMap<Stores, StorePreviewModel>()
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoresId))
                .ReverseMap();

            CreateMap<Descriptions, DescriptionPreviewModel>().ReverseMap();
        }
    }
}
