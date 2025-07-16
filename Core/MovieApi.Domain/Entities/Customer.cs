using Domain.Common;

namespace Domain.Entities;

public class Customer : User
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<PurchasedMovie> PurchasedMovies { get; set; }
    public virtual ICollection<Genre> FavoriteGenres { get; set; }

}