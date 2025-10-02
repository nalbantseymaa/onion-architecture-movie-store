using MovieApi.Domain.Common;

namespace MovieApi.Domain.Entities;

public class Actor : Person
{
    public virtual ICollection<Movie> ActedMovies { get; set; }

}