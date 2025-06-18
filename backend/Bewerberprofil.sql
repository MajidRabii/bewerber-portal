-- View: public.Bewerberprofil

-- DROP VIEW public."Bewerberprofil";

CREATE OR REPLACE VIEW public."Bewerberprofil"
 AS
 SELECT person."Id" AS "PersonId",
    person."Anrede",
    person."Vorname",
    person."Nachname",
    person."Geburtstag",
    person."Geburtsort_Id",
	stadt1."Name" AS "Geburtsort_Name",
    person."Adresse",
    person."Laendercode",
    person."Handynummer",
    person."Bild",
    person."Bild_Datei",
    person."Bild_Name",
    person."Bild_Type",
    profil."Id" AS "ProfilId",
    profil."Person_Id",
    profil."Beruf1_Id",
    beruf1."Name_DE" AS "Beruf1_Name",
    profil."Erfahrung1",
    profil."Beruf2_Id",
	beruf2."Name_DE" AS "Beruf2_Name",
    profil."Erfahrung2",
    profil."Abschlussart_Id",
	Abschlussart."Name_DE" AS "Abschlussart_Name",
    profil."Studiengang_Id",
	Studiengang."Name_DE" AS "Studiengang_Name",
	profil."Einrichtung",
    profil."Studienort_Id",
	stadt2."Name" AS "Studienort_Name",
    profil."Anerkennung",
    profil."Deutsch_Id",
        CASE profil."Deutsch_Id"
            WHEN 0 THEN 'Anfänger'::text
            WHEN 1 THEN 'Gut'::text
            WHEN 2 THEN 'Sehr Gut'::text
            WHEN 3 THEN 'Muttersprache'::text
            ELSE 'Unbekannt'::text
        END AS "Deutsch_Name",
	profil."Niveau_Id",
        CASE profil."Niveau_Id"
            WHEN 0 THEN 'Nein'::text
            WHEN 1 THEN 'A1'::text
            WHEN 2 THEN 'A2'::text
            WHEN 3 THEN 'B1'::text
            WHEN 1 THEN 'B2'::text
            WHEN 2 THEN 'C1'::text
            WHEN 3 THEN 'C2'::text
			ELSE 'Unbekannt'::text
        END AS "Niveau_Name",
	profil."Englisch_Id",
        CASE profil."Englisch_Id"
            WHEN 0 THEN 'Anfänger'::text
            WHEN 1 THEN 'Gut'::text
            WHEN 2 THEN 'Sehr Gut'::text
            WHEN 3 THEN 'Muttersprache'::text
            ELSE 'Unbekannt'::text
        END AS "Englisch_Name",
	profil."Zertifikate_Id",
        CASE profil."Zertifikate_Id"
            WHEN 0 THEN 'Nein'::text
            WHEN 1 THEN 'IELTS'::text
            WHEN 2 THEN 'TOEFL'::text
            ELSE 'Unbekannt'::text
        END AS "Zertifikate_Name",
    profil."Persisch_Id",
        CASE profil."Persisch_Id"
            WHEN 0 THEN 'Anfänger'::text
            WHEN 1 THEN 'Gut'::text
            WHEN 2 THEN 'Sehr Gut'::text
            WHEN 3 THEN 'Muttersprache'::text
            ELSE 'Unbekannt'::text
        END AS "Persisch_Name",
    profil."Fuehrerschein_Id",
        CASE profil."Fuehrerschein_Id"
            WHEN 0 THEN 'Nein'::text
            WHEN 1 THEN 'B (B197)'::text
            WHEN 2 THEN 'B (Schalten)'::text
            WHEN 3 THEN 'B (Automatik)'::text
            ELSE 'Unbekannt'::text
        END AS "Fuehrerschein_Name",
	profil."Auto",
    profil."Einsatzwunsch_Id",
        CASE profil."Einsatzwunsch_Id"
            WHEN 0 THEN 'Vollzeit'::text
            WHEN 1 THEN 'Teilzeit'::text
            WHEN 2 THEN 'Minijob'::text
            ELSE 'Unbekannt'::text
        END AS "Einsatzwunsch_Name",
    profil."Lebenslauf",
    profil."Lebenslauf_Datei",
    profil."Lebenslauf_Name",
    profil."Lebenslauf_Type",
    profil."Bewerbung",
    profil."Bewerbung_Datei",
    profil."Bewerbung_Name",
    profil."Bewerbung_Type",
    profil."Sprachzertifikate",
    profil."Sprachzertifikate_Datei",
    profil."Sprachzertifikate_Name",
    profil."Sprachzertifikate_Type",
    profil."Studiumzertifikate",
    profil."Studiumzertifikate_Datei",
    profil."Studiumzertifikate_Name",
    profil."Studiumzertifikate_Type",
    profil."Arbeitserlaubnis",
    profil."Ankunftsdatum",
    profil."Status",
    profil."Erstellen_Date",
    profil."User_Id",
    profil."Zuletzt_Aktiv_Date"
   FROM profil
     JOIN person ON profil."Person_Id" = person."Id"
     LEFT JOIN beruf beruf1 ON profil."Beruf1_Id" = beruf1."Id"
	 LEFT JOIN stadt stadt1 ON person."Geburtsort_Id" = stadt1."Id"
	 LEFT JOIN stadt stadt2 ON profil."Studienort_Id" = stadt2."Id"
	 LEFT JOIN Abschlussart ON profil."Abschlussart_Id" = Abschlussart."Id"
	 LEFT JOIN Studiengang  ON profil."Studiengang_Id" = Studiengang."Id"
	 LEFT JOIN beruf beruf2 ON profil."Beruf2_Id" = beruf2."Id";

ALTER TABLE public."Bewerberprofil"
    OWNER TO postgres;

