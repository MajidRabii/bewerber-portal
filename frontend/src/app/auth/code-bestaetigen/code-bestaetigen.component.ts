import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { PasswortVergebenComponent } from '../passwort-vergeben/passwort-vergeben.component';
import { RegistrierenComponent } from '../registrieren/registrieren.component';

@Component({
  standalone: true,
  selector: 'app-code-bestaetigen',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatSnackBarModule
  ],
  templateUrl: './code-bestaetigen.component.html',
})
export class CodeBestaetigenComponent {
  formular: FormGroup;
  istLaden = false;

  constructor(
    private dialog: MatDialog,
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.formular = this.fb.group({
      code: ['', Validators.required]
      });
    }

  codePrufen(): void {
    const eingegebenerCode = this.formular.get('code')?.value;
    const benutzer = this.authService.getZwischenspeicher();

    if (!benutzer || !benutzer.code) {
      this.snackBar.open('Fehler: kein Code gefunden.', 'OK', { duration: 3000 });
      this.dialog.open(RegistrierenComponent, {
        disableClose: true,
      });
      return;
    }

    if (eingegebenerCode === benutzer.code) {
      this.snackBar.open('Code bestätigt.', 'OK', { duration: 2000 });
      this.dialog.open(PasswortVergebenComponent, {
        disableClose: true,
      });
    } else {
      this.snackBar.open('Falscher Code!', 'OK', { duration: 3000 });
    }
  }
}
