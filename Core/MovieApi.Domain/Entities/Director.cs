using Domain.Common;

namespace Domain.Entities;

public class Director : Person
{
    public virtual ICollection<Movie> DirectedMovies { get; set; }

}