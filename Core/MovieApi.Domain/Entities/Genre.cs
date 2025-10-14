using MovieApi.Domain.Common;
using MovieApi.Domain.Entities.Identity;

namespace MovieApi.Domain.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Movie> MoviesInGenre { get; set; }
    public virtual ICollection<AppUser> UsersInGenre { get; set; }

}