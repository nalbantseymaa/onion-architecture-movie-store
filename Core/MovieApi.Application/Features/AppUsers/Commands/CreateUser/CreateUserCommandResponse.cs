namespace MovieApi.Application.Features.AppUsers.Commands.CreateUser;

public class CreateUserCommandResponse
{
    public bool Succeeded { get; set; } = true;
    public string Message { get; set; } = "User created successfully.";

}