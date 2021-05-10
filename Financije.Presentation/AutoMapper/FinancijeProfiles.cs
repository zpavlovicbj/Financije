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
                .ForMember(dest => dest.DescriptionName, opt => opt.MapFrom(src => src.Description.DescriptionName));

            CreateMap<Stores, StorePreviewModel>()
                //.ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoreId))
                .ReverseMap();

            CreateMap<Descriptions, DescriptionPreviewModel>().ReverseMap();

            CreateMap<Accounts, AccountDataCreateModel>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.DescriptionName))
                .ForMember(dest => dest.Store, opt => opt.MapFrom(src => src.Store.StoreName))
                .ForMember(dest => dest.Payin, opt => opt.MapFrom(src => src.Payin.ToString("N2")))
                .ForMember(dest => dest.Payout, opt => opt.MapFrom(src => src.Payout.ToString("N2")));

            CreateMap<AccountDetailsModel, Accounts>();

            CreateMap<AccountDataCreateModel, Accounts>()
                .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.Date.Month))
                .ForMember(dest => dest.Store, opt => opt.MapFrom(src => src.Store));

            CreateMap<Accounts, AccountCreateModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.Store, opt => opt.MapFrom(src => src.Store.StoreName));

             CreateMap<Accounts, AccountPreviewModel>()
                .ForMember(dest => dest.DescriptionName, opt => opt.MapFrom(src => src.Description.DescriptionName))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("d")))
                .ForMember(dest => dest.Payin, opt => opt.MapFrom(src => src.Payin.ToString("N2")))
                .ForMember(dest => dest.Payout, opt => opt.MapFrom(src => src.Payout.ToString("N2")));

            CreateMap<AccountItem, AccountItemModel>();

            CreateMap<AccountItem, AccountCreateModel>()
                .ForMember(dest => dest.Article, opt => opt.MapFrom(src => src.Article.ArticleName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Article.Description.DescriptionName));

        }
    }
}
