using AutoMapper;
using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //סוכן
            CreateMap<Agent, AgentVM>().ReverseMap();

            //לקוח
            CreateMap<Client, ClientVM>().ReverseMap();

            // Custom mapping for ClientForAgentVM
            CreateMap<Client, ClientForAgentVM>()
                .ForMember(dest => dest.SitesName,
                    opt => opt.MapFrom(src =>
                        src.Sites != null
                            ? src.Sites.Select(s => new SiteForClientVM { Name = s.Name }).ToList()
                            : new List<SiteForClientVM>()));

            //אתר
            CreateMap<Site, SiteVM>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client != null ? src.Client.Name : null))
                .ReverseMap();

            CreateMap<Site,SiteForClientVM>().ReverseMap();
        }
    }
}
