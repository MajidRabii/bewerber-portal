namespace BewerbungAPP.Models
{
    public class Profil
    {
        public int Id { get; set; }
        public int Person_Id { get; set; } // Matches Person.Id = Primary Key & Foreign Key
        public int Beruf1_Id { get; set; }
        public short Erfahrung1 { get; set; }
        public int? Beruf2_Id { get; set; }
        public short? Erfahrung2 { get; set; }
        public int Abschlussart_Id { get; set; }
        public int Studiengang_Id { get; set; }
        public string Einrichtung { get; set; } = "";
        public int Studienort_Id { get; set; }
        public bool Anerkennung { get; set; } = false;
        public short Deutsch_Id { get; set; } 
        public short Niveau_Id { get; set; }
        public short Englisch_Id { get; set; }
        public short Zertifikate_Id { get; set; }
        public short Persisch_Id { get; set; }
        public short Fuehrerschein_Id { get; set; }
        public bool Auto { get; set; } = false;
        public short Einsatzwunsch_Id { get; set; }
        public bool Lebenslauf { get; set; } = false;
        public byte[]? Lebenslauf_Datei { get; set; }
        public string? Lebenslauf_Name { get; set; }
        public string? Lebenslauf_Type { get; set; }
        public bool Bewerbung { get; set; } = false;
        public byte[]? Bewerbung_Datei { get; set; }
        public string? Bewerbung_Name { get; set; }
        public string? Bewerbung_Type { get; set; }
        public bool Sprachzertifikate { get; set; } = false;
        public byte[]? Sprachzertifikate_Datei { get; set; }
        public string? Sprachzertifikate_Name { get; set; }
        public string? Sprachzertifikate_Type { get; set; }
        public bool Studiumzertifikate { get; set; } = false;
        public byte[]? Studiumzertifikate_Datei { get; set; }
        public string? Studiumzertifikate_Name { get; set; }
        public string? Studiumzertifikate_Type { get; set; }
        public bool Arbeitserlaubnis { get; set; } = false;
        public DateTime Ankunftsdatum { get; set; }
        public bool Status { get; set; } = true;
        public DateTime Erstellen_Date { get; set; } = DateTime.UtcNow;
        public int User_Id { get; set; }
        public DateTime Zuletzt_Aktiv_Date { get; set; } = DateTime.UtcNow;
 
        // Navigation
        public Person? Person { get; set; }
        public User? User { get; set; }
        public Stadt? Studienort { get; set; }
        public Beruf? Beruf1 { get; set; }
        public Beruf? Beruf2 { get; set; }
        public Abschlussart? Abschlussart { get; set; }
        public Studiengang? Studiengang { get; set; }

    }

}
