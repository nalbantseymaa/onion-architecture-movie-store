using AutoMapper;
using MediatR;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Features.Actors.Commands.CreateActor;

public class CreateActorHandler : IRequestHandler<CreateActorRequest, int>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateActorHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<int> Handle(CreateActorRequest request, CancellationToken cancellationToken)
    {
        var actor = mapper.Map<Actor>(request);
        actor.CreatedBy = "system";
        actor.CreatedAt = DateTime.UtcNow;
        await unitOfWork.GetWriteRepository<Actor>().AddAsync(actor);
        return await unitOfWork.SaveChangesAsync();
    }
}




