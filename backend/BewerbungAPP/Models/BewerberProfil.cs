﻿namespace BewerbungAPP.Models;

public class BewerberProfil
{
    public int Id { get; set; }
    public char Anrede { get; set; }
    public string Vorname { get; set; } = "";
    public string Nachname { get; set; } = "";
    public DateTime Geburtstag { get; set; }
    public int Geburtsort_Id { get; set; }
    public string Adresse { get; set; } = "";
    public string Laendercode { get; set; } = "";
    public string Handynummer { get; set; } = "";
    public int Beruf1_Id { get; set; }
    public short Erfahrung1 { get; set; }
    public int? Beruf2_Id { get; set; }
    public short? Erfahrung2 { get; set; }
    public int Abschlussart_Id { get; set; }
    public int Studiengang_Id { get; set; }
    public string Einrichtung { get; set; } = "";
    public int Studienort_Id { get; set; }
    public bool Anerkennung { get; set; } = false;
    public string Deutsch { get; set; } = "Anfänger";
    public string Niveau { get; set; } = "Nein";
    public string Englisch { get; set; } = "Anfänger";
    public string Zertifikate { get; set; } = "Nein";
    public string Persisch { get; set; } = "Muttersprache";
    public string Fuehrerschein { get; set; } = "Nein";
    public bool Anto { get; set; } = false;
    public string Einsatzwunsch { get; set; } = "Vollzeit";
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
    public User? User { get; set; }
    public Stadt? Geburtsort { get; set; }
    public Stadt? Studienort { get; set; }
    public Beruf? Beruf1 { get; set; }
    public Beruf? Beruf2 { get; set; }
    public Abschlussart? Abschlussart { get; set; }
    public Studiengang? Studiengang { get; set; }

}
