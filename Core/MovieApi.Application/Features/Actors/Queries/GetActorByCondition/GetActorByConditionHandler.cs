using AutoMapper;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.DTOs;
using MovieApi.Application.Features.Actors.Queries.GetActorByCondition;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Features.Actors.Queries.GetAll;

public class GetActorByConditionHandler : IRequestHandler<GetActorByConditionRequest, GetActorByConditionResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetActorByConditionHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetActorByConditionResponse> Handle(GetActorByConditionRequest request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Actor>(true);

        if (!string.IsNullOrEmpty(request.FirstName))
            predicate = predicate.And(a => a.FirstName == request.FirstName);

        if (!string.IsNullOrEmpty(request.MiddleName))
            predicate = predicate.And(a => a.MiddleName == request.MiddleName);

        if (!string.IsNullOrEmpty(request.LastName))
            predicate = predicate.And(a => a.LastName == request.LastName);

        var actor = await unitOfWork.GetReadRepository<Actor>().GetAsync(
            predicate: predicate,
            include: source => source
                 .Include(a => a.ActedMovies)
                     .ThenInclude(am => am.Genre)
                 .Include(a => a.ActedMovies)
                     .ThenInclude(am => am.Director)
                 .Include(a => a.ActedMovies)
                     .ThenInclude(am => am.Actors)
        );

        if (actor == null)
            throw new Exception("Actor not found");

        var actorDto = mapper.Map<ActorDto>(actor);
        var movieDtos = actor.ActedMovies != null && actor.ActedMovies.Any()
            ? mapper.Map<IList<MovieDto>>(actor.ActedMovies)
            : new List<MovieDto>();

        return new GetActorByConditionResponse
        {
            Actor = actorDto,
            ActedMovies = movieDtos
        };
    }
}

