namespace Domain.Entities;

public class PurchasedMovie
{
    public long Id { get; set; } 
    public long CustomerId { get; set; }
    public long MovieId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Movie Movie { get; set; }

}