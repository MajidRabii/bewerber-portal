namespace BewerbungAPP.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string Type { get; set; } = "user";
    public bool Status { get; set; } = true;
    public DateTime Created_At { get; set; } = DateTime.UtcNow;
    public DateTime Last_Active_At { get; set; } = DateTime.UtcNow;
}
