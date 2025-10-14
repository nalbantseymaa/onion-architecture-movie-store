using AutoMapper;
using MovieApi.Application.DTOs;
using MovieApi.Application.Features.Actors.Commands.AddActors;
using MovieApi.Application.Features.Actors.Commands.CreateActor;
using MovieApi.Application.Features.Actors.Commands.UpdateActor;
using MovieApi.Application.Features.Actors.Queries.GetAllActors;
using MovieApi.Application.Features.AppUsers.Commands.CreateUser;
using MovieApi.Domain.Entities;
using MovieApi.Domain.Entities.Identity;

namespace MovieApi.Application.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        //CreateMap<Source, Destination>();
        CreateMap<Actor, ActorDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                string.IsNullOrEmpty(src.MiddleName)
                    ? $"{src.FirstName} {src.LastName}"
                    : $"{src.FirstName} {src.MiddleName} {src.LastName}"));
        CreateMap<ActorDto, Actor>();
        CreateMap<CreateActorRequest, Actor>();
        CreateMap<AddActorItem, Actor>();
        CreateMap<UpdateActorRequest, Actor>()
            .ForMember(dest => dest.MiddleName, opt => opt.Condition(src => src.MiddleName != null));


        CreateMap<Movie, MovieDto>()
            .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director != null ? $"{src.Director.FirstName} {src.Director.MiddleName} {src.Director.LastName}" : string.Empty))
            .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre != null ? src.Genre.Name : string.Empty))
            .ForMember(dest => dest.ActorNames, opt => opt.MapFrom(src => src.Actors != null ? src.Actors.Select(a => $"{a.FirstName} {a.MiddleName} {a.LastName}").ToList() : new List<string>()));
        CreateMap<MovieDto, Movie>();

        CreateMap<CreateUserCommandRequest, AppUser>().ForMember
        (src => src.OpenDate, opt => opt.MapFrom(dest => DateTime.Now));

    }
}


