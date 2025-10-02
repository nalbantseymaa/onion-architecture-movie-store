using MovieApi.Domain.Common;

namespace MovieApi.Domain.Entities;

public class Director : Person
{
    public virtual ICollection<Movie> DirectedMovies { get; set; }

}