import { Component, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogRef } from '@angular/material/dialog';
import { MatDialog } from '@angular/material/dialog';
import { RegistrierenComponent } from '../registrieren/registrieren.component';
//import { MainFormComponent } from '../../layout/main-layout.component';

@Component({
  selector: 'app-login',
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
  templateUrl: './login.component.html',
  //styleUrls: ['./login.component.css']
})
export class LoginComponent {
  formular: FormGroup;
  istLaden = false;

  constructor(
    private dialog: MatDialog,
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    @Optional() public dialogRef: MatDialogRef<LoginComponent>,
    private snackBar: MatSnackBar
  ) {
    this.formular = this.fb.group({
      benutzernameOderEmail: ['', [Validators.required]],
      passwort: ['', [Validators.required]]
    });
  }

  anmelden() {
    if (this.formular.invalid) return;

    this.istLaden = true;
    const benutzernameOderEmail = this.formular.value.benutzernameOderEmail;
    const passwort = this.formular.value.passwort;
    

    this.authService.anmelden(benutzernameOderEmail, passwort).subscribe({
      next: () => {
        this.snackBar.open('Erfolgreich angemeldet!', 'OK', { duration: 3000 });
        if (this.dialogRef) {
          this.authService.setzeEingeloggtStatus(true);
          this.dialogRef.close();
        } else {
          this.router.navigate(['/mainform']);
        }
      },
      error: (err) => {
        this.snackBar.open('Benutzername/Email oder Passwort falsch.', 'OK', { duration: 3000 });
        this.istLaden = false;
      }
    });
  }

  zurRegistrierung() {
    this.dialog.open(RegistrierenComponent, {
      disableClose: true,
    });
  }
}
