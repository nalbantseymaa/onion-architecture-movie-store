namespace MovieApi.Domain.Common;

public class Person : BaseEntity
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }

    // Additional properties or methods can be added here as needed
}
