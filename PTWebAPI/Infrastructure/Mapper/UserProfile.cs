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
            CreateMap<Models.User, Entities.User>();
            CreateMap<Models.Hair, Entities.Hair>();
            CreateMap<Models.Coordinates, Entities.Coordinates>();
            CreateMap<Models.Company, Entities.Company>();
            CreateMap<Models.Address, Entities.Address>();
            CreateMap<Models.Bank, Entities.Bank>();

            CreateMap<Models.Post, Entities.Post>();
            CreateMap<Models.Todo, Entities.Todo>();
            CreateMap<Entities.User, Entities.UserQuery>();
            CreateMap<Entities.Post, Entities.PostQuery>();
        }
    }
}
