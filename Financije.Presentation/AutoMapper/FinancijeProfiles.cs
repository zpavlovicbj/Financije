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
            CreateMap<Stores, StorePreviewModel>().ReverseMap();
            
        }
    }
}
