using LinqKit;
using MediatR;
using MovieApi.Application.Features.Actors.Queries.GetActorCount;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Features.Actors.Queries.GetActorsByPaging;

public class GetActorCountHandler : IRequestHandler<GetActorCountRequest, GetActorCountResponse>
{
    private readonly IUnitOfWork unitOfWork;

    public GetActorCountHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<GetActorCountResponse> Handle(GetActorCountRequest request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Actor>(true);
        if (request.IsActive.HasValue)
            predicate = predicate.And(a => a.IsDeleted != request.IsActive.Value);
        else
            predicate = predicate.And(a => true);

        var count = await unitOfWork.GetReadRepository<Actor>().CountAsync(
            predicate: predicate
        );

        if (count < 0)
            throw new Exception("Could not retrieve actor count");

        return new GetActorCountResponse { Count = count };
    }
}




