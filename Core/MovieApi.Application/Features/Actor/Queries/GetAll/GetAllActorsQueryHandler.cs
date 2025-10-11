using MediatR;
using MovieApi.Application.Interfaces.UnitOfWorks;

namespace MovieApi.Application.Features.Actor.Queries.GetAll;

public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQueryRequest, IList<GetAllActorsQueryResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllActorsQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IList<GetAllActorsQueryResponse>> Handle(GetAllActorsQueryRequest request, CancellationToken cancellationToken)
    {
        var actors = await unitOfWork.GetReadRepository<Domain.Entities.Actor>().GetAllAsync();

        List<GetAllActorsQueryResponse> response = new();

        foreach (var actor in actors)
            response.Add(new GetAllActorsQueryResponse
            {
                FirstName = actor.FirstName,
                MiddleName = actor.MiddleName,
                LastName = actor.LastName,
                ActedMovies = actor.ActedMovies.Select(movie => movie.Title).ToList()
            });
        return response;

    }
}

