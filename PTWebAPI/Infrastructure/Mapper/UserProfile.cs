using AutoMapper;
using Entities = User.Microservice.Domain.Entities;
using Models = User.Microservice.Application.Models;
namespace User.Microservice.Infrastructure.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Default mapping when property names are same
            CreateMap<Models.User, Entities.User>().ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.id));
            CreateMap<Models.Hair, Entities.Hair>();
            CreateMap<Models.Coordinates, Entities.Coordinates>();
            CreateMap<Models.Company, Entities.Company>();
            CreateMap<Models.Address, Entities.Address>();
            CreateMap<Models.Bank, Entities.Bank>();

            CreateMap<Models.Post, Entities.Post>().ForMember(dest => dest.postid, opt => opt.MapFrom(src => src.id));
            CreateMap<Models.Todo, Entities.Todo>().ForMember(dest => dest.todoid, opt => opt.MapFrom(src => src.id));
            CreateMap<Models.Post, Entities.PostQuery>().ForMember(dest => dest.postid, opt => opt.MapFrom(src => src.id));
            CreateMap<Models.Todo, Entities.Todo>().ForMember(dest => dest.todoid, opt => opt.MapFrom(src => src.id));
            CreateMap<Entities.User, Entities.UserQuery>().ForMember(x => x.Todos, opt => opt.Ignore()).ForMember(x => x.Posts, opt => opt.Ignore());
            CreateMap<Entities.Post, Entities.PostQuery>();
            CreateMap<Entities.UserQuery, Models.UserViewModel>().ForMember(x => x.hair, opt => opt.Ignore()).ForMember(x => x.address, opt => opt.Ignore()).ForMember(x => x.company, opt => opt.Ignore()).ForMember(x => x.bank, opt => opt.Ignore());
            CreateMap<Entities.Todo, Models.Todo>();
        }
    }
}
