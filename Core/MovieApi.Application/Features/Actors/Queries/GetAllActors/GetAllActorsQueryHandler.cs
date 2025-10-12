using AutoMapper;
using MediatR;
using MovieApi.Application.DTOs;
using MovieApi.Application.Features.Actors.Queries.GetAllActors;
using MovieApi.Application.Interfaces.UnitOfWorks;

namespace MovieApi.Application.Features.Actors.Queries.GetAll;

public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQueryRequest, GetAllActorsQueryResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllActorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetAllActorsQueryResponse> Handle(GetAllActorsQueryRequest request, CancellationToken cancellationToken)
    {
        var actors = await unitOfWork.GetReadRepository<Domain.Entities.Actor>().GetAllAsync();
        if (actors == null || actors.Count == 0)
            throw new Exception("Failed to retrieve actors");

        var actorDtos = mapper.Map<IList<ActorDto>>(actors);
        var response = new GetAllActorsQueryResponse()
        {
            Actors = actorDtos
        };

        return response;

    }
}

