namespace MovieApi.Application.DTOs;

public class MovieDto
{
    public string Title { get; set; }
    public string DirectorName { get; set; }
    public int ReleaseYear { get; set; }
    public string GenreName { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public IList<string> ActorNames { get; set; }
}