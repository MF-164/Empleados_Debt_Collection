using AutoMapper;
using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.Models;


namespace Debt_Collection_CORE
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Agent <-> AgentVM
            CreateMap<Agent, AgentVM>()
                 .ForMember(dest => dest.Clients, opt => opt.MapFrom(src =>
                     src.Clients != null
                         ? src.Clients.Select(c => new ClientForAgentVM
                         {
                             Name = c.Name,
                             SitesName = c.Sites != null
                                   ? c.Sites.Select(s => new SiteForClientVM { Name = s.Name }).ToList()
                                   : new List<SiteForClientVM>()
                         }).ToList()
                         : new List<ClientForAgentVM>()))
                 .ReverseMap();


            // Client <-> ClientVM (with AgentName and Sites)
            CreateMap<Client, ClientVM>()
                .ForMember(dest => dest.AgentName, opt => opt.MapFrom(src => src.Agent != null ? src.Agent.Name : null))
                .ForMember(dest => dest.Sites, opt => opt.MapFrom(src =>
                    src.Sites != null
                        ? src.Sites.Select(s => new SiteForClientVM { Name = s.Name }).ToList()
                        : new List<SiteForClientVM>()))
                .ReverseMap()
                .ForMember(dest => dest.Agent, opt => opt.Ignore());

            // Site <-> SiteVM (with ClientName)
            CreateMap<Site, SiteVM>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client != null ? src.Client.Name : null))
                .ReverseMap()
                .ForMember(dest => dest.Client, opt => opt.Ignore());

        }
    }
}
