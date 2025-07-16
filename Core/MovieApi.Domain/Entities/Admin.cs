using Domain.Common;

namespace Domain.Entities;

public class Admin : User
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }

}