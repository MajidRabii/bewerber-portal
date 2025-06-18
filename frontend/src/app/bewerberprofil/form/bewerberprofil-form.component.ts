// ✅ Refactored BewerberprofilFormComponent - preserving all features and fixing view-mode loading

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';

import { FileUploadComponent } from '../../file-upload/file-upload.component';
import { BewerberProfilService } from '../../services/bewerberprofil.service';
import { StadtService } from '../../stadt-form/stadt.service';
import { BerufService } from '../../services/beruf.service';
import { AbschlussartService } from '../../services/abschlussart.service';
import { StudiengangService } from '../../services/studiengang.service';
import { EnumService } from '../../services/enum.service';
import { EnumItem } from '../../models/enum-item.model';
import { BewerberProfilViewModel } from '../../models/bewerberprofil.model';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-bewerberprofil-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatSnackBarModule,
    FileUploadComponent
  ],
  templateUrl: './bewerberprofil-form.component.html',
  styleUrls: ['./bewerberprofil-form.component.scss']
})
export class BewerberprofilFormComponent implements OnInit {
  form!: FormGroup;
  id!: number;
  isEditMode = false;
  isViewMode = false;
  loading = true;
  benutzerEmail: string = '';
  // Dropdown data
  staedte: any[] = [];
  berufe: any[] = [];
  abschlussarten: any[] = [];
  studiengange: any[] = [];
  deutsch: EnumItem[] = [];
  niveau: EnumItem[] = [];
  englisch: EnumItem[] = [];
  zertifikate: EnumItem[] = [];
  persisch: EnumItem[] = [];
  fuehrerschein: EnumItem[] = [];
  einsatzwunsch: EnumItem[] = [];

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar,
    private bewerberService: BewerberProfilService,
    private stadtService: StadtService,
    private berufService: BerufService,
    private abschlussartService: AbschlussartService,
    private studiengangService: StudiengangService,
    private enumService: EnumService
  ) {}

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.isViewMode = params.get('view') === 'true';
      this.id = Number(this.route.snapshot.paramMap.get('id'));
      this.isEditMode = !!this.id && !this.isViewMode;

      this.initializeLists();

      if (this.id) {
        this.loadForEdit(this.id);
      } else {
        this.initializeCreateForm();
      }
      // ✅ فقط وقتی فرم تازه ساخته شد، ایمیل ست کن
      this.authService.benutzer$.subscribe(benutzer => {
        if (benutzer) {
          this.benutzerEmail = benutzer.email;
          this.form.get('email')?.setValue(benutzer.email);
        }
      });
    });
  }

  initializeLists() {
    this.stadtService.getStadtAll().subscribe(data => this.staedte = data);
    this.berufService.getBerufAll().subscribe(data => this.berufe = data);
    this.abschlussartService.getAbschlussartAll().subscribe(data => this.abschlussarten = data);
    this.studiengangService.getStudiengangAll().subscribe(data => this.studiengange = data);

    this.enumService.getDeutsch().subscribe(data => this.deutsch = data);
    this.enumService.getNiveau().subscribe(data => this.niveau = data);
    this.enumService.getEnglisch().subscribe(data => this.englisch = data);
    this.enumService.getZertifikate().subscribe(data => this.zertifikate = data);
    this.enumService.getPersisch().subscribe(data => this.persisch = data);
    this.enumService.getFuehrerschein().subscribe(data => this.fuehrerschein = data);
    this.enumService.getEinsatzwunsch().subscribe(data => this.einsatzwunsch = data);
  }

  initializeCreateForm(): void {
    this.form = this.fb.group({
      personId: [0],
      vorname: ['', Validators.required],
      nachname: ['', Validators.required],
      geburtstag: ['', Validators.required],
      anrede: ['', Validators.required],
      geburtsort_Id: [null, Validators.required],
      geburtsort_Name: [''],
      email: [''],
      adresse: [''],
      laendercode: [''],
      handynummer: ['', Validators.required],
      bild: [false],
      bild_Datei: [''],
      bild_Name: [''],
      bild_Type: [''],
      profilId: [0],
      person_Id: [0],
      beruf1_Id: [null, Validators.required],
      beruf1_Name: [''],
      erfahrung1: [0, Validators.required],
      beruf2_Id: [null],
      beruf2_Name: [''],
      erfahrung2: [null],
      abschlussart_Id: [null],
      abschlussart_Name: [''],
      studiengang_Id: [null],
      studiengang_Name: [''],
      einrichtung: [''],
      studienort_Id: [null],
      studienort_Name: [''],
      anerkennung: [false],
      deutsch_Id: [0],
      deutsch_Name: [''],
      niveau_Id: [0],
      niveau_Name: [''],
      englisch_Id: [0],
      englisch_Name: [''],
      zertifikate_Id: [0],
      zertifikate_Name: [''],
      persisch_Id: [0],
      persisch_Name: [''],
      fuehrerschein_Id: [0],
      fuehrerschein_Name: [''],
      auto: [false],
      einsatzwunsch_Id: [0],
      einsatzwunsch_Name: [''],
      lebenslauf: [false],
      lebenslauf_Datei: [''],
      lebenslauf_Name: [''],
      lebenslauf_Type: [''],
      bewerbung: [false],
      bewerbung_Datei: [''],
      bewerbung_Name: [''],
      bewerbung_Type: [''],
      sprachzertifikate: [false],
      sprachzertifikate_Datei: [''],
      sprachzertifikate_Name: [''],
      sprachzertifikate_Type: [''],
      studiumzertifikate: [false],
      studiumzertifikate_Datei: [''],
      studiumzertifikate_Name: [''],
      studiumzertifikate_Type: [''],
      arbeitserlaubnis: [false],
      ankunftsdatum: ['', Validators.required],
      status: [true],
      erstellen_Date: [''],
      user_Id: [null],
      zuletzt_Aktiv_Date: ['']
    });
  }

  loadForEdit(id: number): void {
    this.bewerberService.getById(id).subscribe({
      next: (data) => {
        this.initializeCreateForm();
        this.form.patchValue(data);
        this.form.get('email')?.setValue(this.benutzerEmail);
        if (this.isViewMode) this.form.disable();
        this.loading = false;
      },
      error: () => {
        this.snackBar.open('Fehler beim Laden des BewerbersProfil.', 'OK', { duration: 3000 });
        this.router.navigate(['/bewerberprofil-list']);
      }
    });
  }

  onSubmit(): void {
    if (this.isViewMode || this.form.invalid) return;

    const model = this.form.value as BewerberProfilViewModel;

    const request: Observable<void | BewerberProfilViewModel> = this.isEditMode
      ? this.bewerberService.update(this.id, model)
      : this.bewerberService.create(model);

    request.subscribe({
      next: () => {
        this.snackBar.open('Erfolgreich gespeichert.', 'OK', { duration: 3000 });
        this.router.navigate(['/bewerberprofil-list']);
      },
      error: (err) => {
        console.error('Fehler beim Speichern:', err); // 👈 چاپ خطا در Console
        this.snackBar.open('Fehler beim Speichern.', 'OK', { duration: 3000 });
      }
      //error: () => this.snackBar.open('Fehler beim Speichern.', 'OK', { duration: 3000 })
    });
  }

  onFileSelected(event: { file: File; field: string; base64: string; name: string; type: string; }): void {
    const { file, field, base64, name, type } = event;

    if (field === 'bild') {
      this.form.patchValue({
        bild: true,
        bild_Datei: base64,
        bild_Name: name,
        bild_Type: type
      });
    } else {
      this.form.patchValue({
        [field]: true,
        [`${field}_Datei`]: base64,
        [`${field}_Name`]: name,
        [`${field}_Type`]: type
      });
    }

    console.log('Datei erfolgreich empfangen:', {
      field,
      name,
      type,
      preview: base64.slice(0, 30) + '...'
    });
  }

  loadFileIntoForm(file: File, field: string) {
    const reader = new FileReader();
    reader.onload = () => {
      const base64String = (reader.result as string).split(',')[1]; // Base64 رشته را جدا کن
      this.form.patchValue({
        [field]: true, // مثلا وجود فایل
        [field + '_Datei']: base64String,
        [field + '_Name']: file.name,
        [field + '_Type']: file.type
      });
    };
    reader.readAsDataURL(file);
  }

  triggerFileUpload(field: string): void {
    const input = document.getElementById(field + '-upload') as HTMLInputElement;
    if (input) input.click();
  }

  onCancel(): void {
    this.router.navigate(['/bewerberprofil-list']);
  }

  showImageUpload = false;
  onImageFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (!input.files || input.files.length === 0) return;

    const file: File = input.files[0];
    // بررسی اینکه فایل حتماً تصویر باشد
    if (!file.type.startsWith('image/')) {
      alert('Nur Bilddateien (JPG, PNG, etc.) sind erlaubt!');
      return;
    }
    const reader = new FileReader();

    reader.onload = () => {
      const base64Data = (reader.result as string).split(',')[1];
      this.form.patchValue({
        bild: true,
        bild_Name: file.name,
        bild_Type: file.type,
        bild_Datei: base64Data
      });
    };

    reader.readAsDataURL(file);
  }

  anredeOptionen = [
    { value: 'H', label: 'Herr' },
    { value: 'F', label: 'Frau' },
    { value: 'D', label: 'Divers' }
  ];

  landerCodeOptionen = [
    { value: '+49', label: '🇩🇪 Deutschland (+49)' },
    { value: '+98', label: '🇮🇷 Iran (+98)' },
    { value: '+90', label: '🇹🇷 Türkei (+90)' },
    { value: '+93', label: '🇦🇫 Afghanistan (+93)' },
    { value: '+964', label: '🇮🇶 Irak (+964)' },
    { value: '+963', label: '🇸🇾 Syrien (+963)' },
  ];

}
