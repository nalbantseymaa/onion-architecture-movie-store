using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.DTOs;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Features.Actors.Queries.GetActorsByPaging;

public class GetActorsByPagingHandler : IRequestHandler<GetActorsByPagingRequest, GetActorsByPagingResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetActorsByPagingHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetActorsByPagingResponse> Handle(GetActorsByPagingRequest request, CancellationToken cancellationToken)
    {

        var actors = await unitOfWork.GetReadRepository<Actor>().GetAllByPagingAsync(
            include: source => source.Include(a => a.ActedMovies),
            currentPage: (int)request.CurrentPage,
            pageSize: (int)request.PageSize
        );

        if (actors == null)
            throw new Exception("Actors not found");

        var actorDtos = mapper.Map<List<ActorDto>>(actors);

        return new GetActorsByPagingResponse
        {
            Actors = actorDtos
        };
    }
}




