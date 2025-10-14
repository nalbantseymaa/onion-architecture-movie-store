using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieApi.Domain.Entities.Identity;

namespace MovieApi.Application.Features.AppUsers.Commands.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    //User Manager servis Identity de kullanıcı işlemlerinden sorumlu olan servis
    // bu servisden dolayı repository kullanımı yapmıyoruz.
    private readonly UserManager<AppUser> userManager;
    private readonly IMapper mapper;

    public CreateUserHandler(UserManager<AppUser> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<AppUser>(request);
        user.Id = Guid.NewGuid().ToString();
        IdentityResult result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
            return new CreateUserCommandResponse();

        else
            throw new Exception(string.Join(",", result.Errors.Select(e => e.Description)));
    }

}




