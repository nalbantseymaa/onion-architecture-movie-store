namespace MovieApi.Application.Features.Actor.Queries.GetAll;

public class GetAllActorsQueryResponse
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public List<string> ActedMovies { get; set; } = new List<string>();

}