using Domain.Common;

namespace Domain.Entities;

public class Actor : Person
{
    public virtual ICollection<Movie> ActedMovies { get; set; }

}