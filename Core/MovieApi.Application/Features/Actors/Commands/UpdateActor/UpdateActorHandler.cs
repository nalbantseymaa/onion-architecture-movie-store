using AutoMapper;
using MediatR;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Features.Actors.Commands.UpdateActor;

public class UpdateActorHandler : IRequestHandler<UpdateActorRequest, int>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateActorHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<int> Handle(UpdateActorRequest request, CancellationToken cancellationToken)
    {
        var actor = await unitOfWork.GetReadRepository<Actor>()
            .GetAsync(predicate: x => x.Id == request.ActorId, enableTracking: true);

        if (actor == null)
            return 0;

        mapper.Map(request, actor);
        actor.UpdatedAt = DateTime.UtcNow;
        actor.UpdatedBy = "system";

        unitOfWork.GetWriteRepository<Actor>().Update(actor);

        return await unitOfWork.SaveChangesAsync();
    }

}




