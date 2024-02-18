using AutoMapper;
using Business.Abstractions.IO.User;
using Entities.Entities;

namespace Presentation.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, UserOutput>();
            CreateMap<UserInsertInput, UserEntity>();
            CreateMap<UserUpdateInput, UserEntity>();
        }
    }
}
