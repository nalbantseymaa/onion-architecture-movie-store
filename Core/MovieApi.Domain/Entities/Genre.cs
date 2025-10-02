using MovieApi.Domain.Common;

namespace MovieApi.Domain.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Movie> MoviesInGenre { get; set; }
    public virtual ICollection<User> UsersByGenre { get; set; }

}