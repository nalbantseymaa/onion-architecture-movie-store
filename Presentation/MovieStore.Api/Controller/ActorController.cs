using Microsoft.AspNetCore.Mvc;
using MediatR;
using MovieApi.Application.Features.Actors.Queries.GetAll;
using MovieApi.Application.Features.Actors.Queries.GetActorByCondition;
using MovieApi.Application.Features.Actors.Queries.FindActors;
using MovieApi.Application.Features.Actors.Queries.GetActorsByPaging;
using MovieApi.Application.Features.Actors.Queries.GetActorCount;
using MovieApi.Application.Features.Actors.Commands.CreateActor;
using MovieApi.Application.Features.Actors.Commands.UpdateActor;
using MovieApi.Application.Features.Actors.Commands.AddActors;
using MovieApi.Application.Features.Actors.Commands.DeleteActor;

namespace MovieStore.Api.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly IMediator mediator;

    public ActorController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllActors()
    {
        var result = await mediator.Send(new GetAllActorsQueryRequest());
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetActorByCondition([FromQuery] GetActorByConditionRequest request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> FindActors([FromQuery] FindActorsRequest request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetActorsByPaging([FromQuery] GetActorsByPagingRequest request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetActorByCount([FromQuery] GetActorCountRequest request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateActor([FromBody] CreateActorRequest request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddActors([FromBody] AddActorsRequest request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("{actorId}")]
    public async Task<IActionResult> UpdateActor([FromBody] UpdateActorRequest request, [FromRoute] int actorId)
    {
        request.ActorId = actorId;
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("{actorId}")]
    public async Task<IActionResult> DeleteActor([FromRoute] long actorId)
    {
        var result = await mediator.Send(new DeleteActorRequest() { ActorId = actorId });
        return Ok(result);
    }
}

