using MovieApi.Domain.Common;

namespace MovieApi.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public virtual ICollection<PurchasedMovie> PurchasedMovies { get; set; }
    public virtual ICollection<Genre> FavoriteGenres { get; set; }

}
