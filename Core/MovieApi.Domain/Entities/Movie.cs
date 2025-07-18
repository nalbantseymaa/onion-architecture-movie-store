using Domain.Common;

namespace Domain.Entities;

public class Movie : BaseEntity
{
    public string Title { get; set; }
    public long DirectorId { get; set; }
    public int ReleaseYear { get; set; }
    public long GenreId { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; } //  in minutes
    public virtual ICollection<Actor> Actors
    { get; set; }
    public virtual Director Director
    { get; set; }
    public virtual Genre Genre { get; set; }
    public virtual ICollection<PurchasedMovie> PurchasedMovies { get; set; }

}