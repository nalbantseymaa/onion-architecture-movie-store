using AutoMapper;
using MediatR;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Features.Actors.Commands.AddActors;

public class AddActorsHandler : IRequestHandler<AddActorsRequest, int>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AddActorsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<int> Handle(AddActorsRequest request, CancellationToken cancellationToken)
    {
        var actors = new List<Actor>();
        foreach (var actor in request.Actors)
        {
            var actorEntity = mapper.Map<Actor>(actor);
            actorEntity.CreatedAt = DateTime.UtcNow;
            actorEntity.CreatedBy = "system";
            actors.Add(actorEntity);
        }

        await unitOfWork.GetWriteRepository<Actor>().AddRangeAsync(actors);
        return await unitOfWork.SaveChangesAsync();
    }
}




