export interface BewerberProfilViewModel {
  // Person
  personId: number;
  anrede: string;
  vorname: string;
  nachname: string;
  geburtstag: string;
  geburtsort_Id: number;
  geburtsort_Name: string;
  adresse: string;
  laendercode: string;
  handynummer: string;
  bild: boolean;
  bild_Datei?: string;
  bild_Name?: string;
  bild_Type?: string;

  // Profil
  profilId: number;
  person_Id: number;
  beruf1_Id: number;
  beruf1_Name: string;
  erfahrung1: number;
  beruf2_Id?: number;
  beruf2_Name?: string;
  erfahrung2?: number;
  abschlussart_Id: number;
  abschlussart_Name?: string;
  studiengang_Id: number;
  studiengang_Name?: string;
  einrichtung: string;
  studienort_Id: number;
  studienort_Name?: string;
  anerkennung: boolean;
  deutsch_Id: number;
  deutsch_Name: string;
  niveau_Id: number;
  niveau_Name: string;
  englisch_Id: number;
  englisch_Name: string;
  zertifikate_Id: number;
  zertifikate_Name: string;
  persisch_Id: number;
  persisch_Name: string;
  fuehrerschein_Id: number;
  fuehrerschein_Name: string;
  einsatzwunsch_Id: number;
  einsatzwunsch_Name: string;

  // Dateien
  lebenslauf: boolean;
  lebenslauf_Datei?: string;
  lebenslauf_Name?: string;
  lebenslauf_Type?: string;

  bewerbung: boolean;
  bewerbung_Datei?: string;
  bewerbung_Name?: string;
  bewerbung_Type?: string;

  sprachzertifikate: boolean;
  sprachzertifikate_Datei?: string;
  sprachzertifikate_Name?: string;
  sprachzertifikate_Type?: string;

  studiumzertifikate: boolean;
  studiumzertifikate_Datei?: string;
  studiumzertifikate_Name?: string;
  studiumzertifikate_Type?: string;

  // Weitere Felder
  auto: boolean;
  arbeitserlaubnis: boolean;
  ankunftsdatum: string;
  
  status: boolean;
  erstellen_Date?: string;
  user_Id?: number;
  zuletzt_Aktiv_Date?: string;
}
