using MovieApi.Domain.Entities.Identity;

namespace MovieApi.Domain.Entities;

public class PurchasedMovie
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public long MovieId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
    public virtual AppUser User { get; set; }
    public virtual Movie Movie { get; set; }

}