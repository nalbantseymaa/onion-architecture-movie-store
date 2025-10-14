using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.AppUsers.Commands.CreateUser;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
    {
        CreateUserCommandResponse response = await mediator.Send(request);
        return Ok(response);
    }
}