import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { CodeBestaetigenComponent } from '../code-bestaetigen/code-bestaetigen.component';

@Component({
  selector: 'app-registrieren',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatSnackBarModule
  ],
  templateUrl: './registrieren.component.html',
  styleUrls: ['./registrieren.component.scss']
})

export class RegistrierenComponent {
  formular: FormGroup;

  constructor(
    private dialog: MatDialog,
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.formular = this.fb.group({
      benutzername: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  codeSenden(): void {
    if (this.formular.invalid) return;

    const { benutzername, email } = this.formular.value;

    this.authService.sendCode(email).subscribe({
      next: (code) => {
        this.authService.setZwischenspeicher({ benutzername, email, code });
        this.snackBar.open('Bestätigungscode gesendet.', 'OK', { duration: 3000 });
        this.dialog.open(CodeBestaetigenComponent, {
          disableClose: true,
        });
      },
      error: () => {
        this.snackBar.open('Fehler beim Senden des Codes.', 'OK', { duration: 3000 });
      }
    });
  }

  abbrechen(): void {
    this.router.navigate(['/']);
  }

  zumLogin(): void {
    this.router.navigate(['/login']);
  }
}
