using Domain.Common;

namespace Domain.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Movie> MoviesInGenre { get; set; }
    public virtual ICollection<Customer> CustomersByGenre { get; set; }

}