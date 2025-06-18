namespace BewerbungAPP.Models;

public class Studiengang
{
    public int Id { get; set; }
    public short Code { get; set; }
    public string Name_DE { get; set; } = "";
    public string Name_EN { get; set; } = "";
    public bool Aktiv { get; set; } = true;
}
