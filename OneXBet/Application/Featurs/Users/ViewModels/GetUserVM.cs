namespace OneXBet.Application.Featurs.Users.ViewModels;

public sealed class GetUserVM
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; }

    public string Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdated { get; set; }
}
