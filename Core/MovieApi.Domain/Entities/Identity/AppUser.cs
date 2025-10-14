using Microsoft.AspNetCore.Identity;

namespace MovieApi.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public virtual ICollection<PurchasedMovie> PurchasedMovies { get; set; }
        public virtual ICollection<Genre> FavoriteGenres { get; set; }
    }
}