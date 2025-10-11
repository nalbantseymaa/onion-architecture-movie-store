using MediatR;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Features.Actors.Commands.DeleteActor;

public class DeleteActorHandler : IRequestHandler<DeleteActorRequest, int>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteActorHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteActorRequest request, CancellationToken cancellationToken)
    {
        var actor = await unitOfWork.GetReadRepository<Actor>().GetAsync(predicate: x => x.Id == request.ActorId, enableTracking: true);
        if (actor != null)
        {
            actor.IsDeleted = true;
            unitOfWork.GetWriteRepository<Actor>().Update(actor);
        }
        else
            return 0; //todo

        return await unitOfWork.SaveChangesAsync();
    }
}




