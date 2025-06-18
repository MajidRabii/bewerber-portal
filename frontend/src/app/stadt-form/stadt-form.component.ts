import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { StadtService, Stadt } from './stadt.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-stadt-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule
  ],
  templateUrl: './stadt-form.component.html',
  styleUrls: ['./stadt-form.component.scss']
})
export class StadtFormComponent {
  stadtForm: FormGroup;

 constructor(private fb: FormBuilder, private stadtService: StadtService) {
  this.stadtForm = this.fb.group({
    id: [{ value: '', disabled: true }], 
    code: [null, Validators.required],
    name: ['', Validators.required],
    bundesland: [''],
    aktiv: [true]
  });
 }

 onSubmit(): void {
  if (this.stadtForm.valid) {
    const stadt = this.stadtForm.getRawValue(); // شامل id (غیرفعال) هست ولی مهم نیست
    const payload = {
      code: stadt.code,
      name: stadt.name,
      bundesland: stadt.bundesland,
      aktiv: stadt.aktiv
    };

    this.stadtService.addStadt(payload).subscribe({
      next: (resp) => {
        console.log('Stadt gespeichert:', resp);
        alert(`Stadt wurde erfolgreich gespeichert! ${resp.name}`);
        this.stadtForm.reset(); // فرم رو خالی می‌کنه
      },
      error: (err) => {
        console.error('Fehler beim Speichern:', err);
        alert('Fehler beim Speichern der Stadt!');
      }
    });
  }
 } 
}
