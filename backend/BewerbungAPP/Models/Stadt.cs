namespace BewerbungAPP.Models;

public class Stadt
{
    public int Id { get; set; }
    public short Code { get; set; }
    public string Name { get; set; } = "";
    public string? Bundesland { get; set; }
    public bool Aktiv { get; set; } = true;
}
