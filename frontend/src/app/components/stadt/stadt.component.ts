import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-stadt',
  templateUrl: './stadt.component.html',
})
export class StadtComponent implements OnInit {
  stadtForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.stadtForm = this.fb.group({
      name: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.stadtForm.valid) {
      console.log('Form data:', this.stadtForm.value);
      // به‌زودی: ارسال به API
    }
  }
}
