import { Component, inject } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BenutzerModel } from '../../models/benutzer.model';
import * as bcrypt from 'bcryptjs';

@Component({
  selector: 'app-passwort-vergeben',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './passwort-vergeben.component.html',
  styleUrls: ['./passwort-vergeben.component.scss']
})
export class PasswortVergebenComponent {
  private fb = inject(FormBuilder);
  private router = inject(Router);
  private authService = inject(AuthService);
  private snackBar = inject(MatSnackBar);

  formular: FormGroup = this.fb.group({
    passwort: [
      '',
      [
        Validators.required,
        Validators.minLength(8),
        Validators.pattern(/(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_])/)
      ]
    ],
    passwortWiederholen: ['']
  }, {
    validators: (group: FormGroup) => {
      return group.get('passwort')?.value === group.get('passwortWiederholen')?.value
        ? null
        : { passwortMismatch: true };
    }
  });

  passwortFestlegen(): void {
    if (this.formular.invalid) return;
    const passwort = this.formular.get('passwort')?.value;
    const salt = bcrypt.genSaltSync(10); // می‌تونی 8 تا 12 بدی بسته به سرعت/امنیت
    const benutzer = this.authService.getZwischenspeicher();
    if (!benutzer) return;
    const neuerBenutzer: Omit<BenutzerModel, 'id'> = {
      name: benutzer.benutzername,
      email: benutzer.email,
      password: passwort,
      status: true,
      type: 'user'
    };

    this.authService.registrieren(neuerBenutzer).subscribe({
      next: () => {
        this.snackBar.open('Registrierung erfolgreich!', 'OK', { duration: 3000 });
        this.router.navigate(['/bewerberprofil-form']);
      },
      error: (err) => {
        console.error('Fehler bei Registrierung:', err);
        this.snackBar.open('Fehler bei der Registrierung.', 'OK', { duration: 3000 });
      }
    });

  }
}
