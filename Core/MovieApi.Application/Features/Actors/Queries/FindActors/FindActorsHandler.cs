using AutoMapper;
using LinqKit;
using MediatR;
using MovieApi.Application.DTOs;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Features.Actors.Queries.FindActors;

public class FindActorsHandler : IRequestHandler<FindActorsRequest, IList<FindActorsResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public FindActorsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<IList<FindActorsResponse>> Handle(FindActorsRequest request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Actor>(true);

        if (!string.IsNullOrEmpty(request.FirstName))
            predicate = predicate.And(a => a.FirstName == request.FirstName);

        if (!string.IsNullOrEmpty(request.MiddleName))
            predicate = predicate.And(a => a.MiddleName == request.MiddleName);

        if (!string.IsNullOrEmpty(request.LastName))
            predicate = predicate.And(a => a.LastName == request.LastName);

        var actors = unitOfWork.GetReadRepository<Actor>().Find(predicate: predicate);

        // TODO  BASE RESPONSE 
        if (actors == null)
            return new List<FindActorsResponse>()
            {
                // Message = "Actors not found" 
            };

        var actorDtos = mapper.Map<IList<ActorDto>>(actors);
        var response = new List<FindActorsResponse>();

        foreach (var actorDto in actorDtos)
        {
            response.Add(new FindActorsResponse
            {
                Actor = actorDto

            });
        }
        return response;
    }
}






