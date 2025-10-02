namespace MovieApi.Domain.Entities;

public class PurchasedMovie
{
    public Guid Id { get; set; }
    public long UserId { get; set; }
    public long MovieId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
    public virtual User User { get; set; }
    public virtual Movie Movie { get; set; }

}