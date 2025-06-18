// ViewModel for combined BewerberProfil (Person + Profil)
namespace BewerbungAPP.ViewModels
{
    public class BewerberProfilViewModel
    {
        public int PersonId { get; set; }
        public char Anrede { get; set; }
        public string Vorname { get; set; } = "";
        public string Nachname { get; set; } = "";
        public DateTime Geburtstag { get; set; }
        public int Geburtsort_Id { get; set; }
        public string Geburtsort_Name { get; set; } = "";
        public string Adresse { get; set; } = "";
        public string Laendercode { get; set; } = "";
        public string Handynummer { get; set; } = "";
        public bool Bild { get; set; } = false;
        public byte[]? Bild_Datei { get; set; }
        public string? Bild_Name { get; set; }
        public string? Bild_Type { get; set; }

        public int ProfilId { get; set; }
        public int Person_Id { get; set; }
        public int Beruf1_Id { get; set; }
        public string Beruf1_Name { get; set; } = "";
        public short Erfahrung1 { get; set; }
        public int? Beruf2_Id { get; set; }
        public string? Beruf2_Name { get; set; } = "";
        public short? Erfahrung2 { get; set; }
        public int Abschlussart_Id { get; set; }
        public string? Abschlussart_Name { get; set; }
        public int Studiengang_Id { get; set; }
        public string? Studiengang_Name { get; set; } = "";
        public string Einrichtung { get; set; } = "";
        public int Studienort_Id { get; set; }
        public string? Studienort_Name { get; set; } = "";
        public bool Anerkennung { get; set; } = false;
        public short Deutsch_Id { get; set; }
        public string Deutsch_Name { get; set; } = "";
        public short Niveau_Id { get; set; }
        public string Niveau_Name { get; set; } = "";
        public short Englisch_Id { get; set; }
        public string Englisch_Name { get; set; } = "";
        public short Zertifikate_Id { get; set; }
        public string Zertifikate_Name { get; set; } = "";
        public short Persisch_Id { get; set; }
        public string Persisch_Name { get; set; } = "";
        public short Fuehrerschein_Id { get; set; }
        public string Fuehrerschein_Name { get; set; } = "";
        public bool Auto { get; set; } = false;
        public short Einsatzwunsch_Id { get; set; }
        public string Einsatzwunsch_Name { get; set; } = "";
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
        public DateTime? Erstellen_Date { get; set; } = DateTime.UtcNow;
        public int User_Id { get; set; }
        public DateTime? Zuletzt_Aktiv_Date { get; set; } = DateTime.UtcNow;
    }
}