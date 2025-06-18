namespace BewerbungAPP.Models
{
    public class Person
    {
        public int Id { get; set; }  // Primary Key
        public char Anrede { get; set; }
        public string Vorname { get; set; } = "";
        public string Nachname { get; set; } = "";
        public DateTime Geburtstag { get; set; }
        public int Geburtsort_Id { get; set; }
        public string Adresse { get; set; } = "";
        public string Laendercode { get; set; } = "";
        public string Handynummer { get; set; } = "";
        public bool Bild { get; set; } = false;
        public byte[]? Bild_Datei { get; set; }
        public string? Bild_Name { get; set; }
        public string? Bild_Type { get; set; }
        public bool Status { get; set; } = true;
        public DateTime Erstellen_Date { get; set; } = DateTime.UtcNow;
        public int User_Id { get; set; }
        public DateTime Zuletzt_Aktiv_Date { get; set; } = DateTime.UtcNow;

        // Navigation 
        public User? User { get; set; }
        public Stadt? Geburtsort { get; set; }
    }
}
