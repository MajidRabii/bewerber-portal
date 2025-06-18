import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FormGroup } from '@angular/forms';
import { NgIf } from '@angular/common';

export interface UploadedFile {
  file: File;
  field: string;
  base64: string;
  name: string;
  type: string;
}

@Component({
  selector: 'app-file-upload',
  standalone: true,
  imports: [MatIconModule, MatButtonModule, NgIf],
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss'],
})

export class FileUploadComponent {
  @Input() field!: string;
  @Input() label!: string;
  @Input() fileName: string | null = null;
  @Input() disabled: boolean = false;
  @Input() isViewMode: boolean = false; 
  @Input() form!: FormGroup;   // بدون این، Angular خط قرمز می‌ده
  @Input() fieldPrefix!: string;
  @Input() accept: string = '*/*'; // پیش‌فرض همه نوع فایل
  @Input() show: boolean = true;

  @Output() fileSelected = new EventEmitter<UploadedFile>();

  /*@Output() fileSelected = new EventEmitter<{
    file: File;
    field: string;
    base64: string;
    name: string;
    type: string;
  }>();*/

  fileDataUrl: string | null = null;

  get isImageType(): boolean {
    return !!this.accept && this.accept.includes('image');
  }

  onFileChange(event: Event): void {
    event.stopPropagation();
    event.preventDefault();
    const input = event.target as HTMLInputElement;
    if (!input.files || input.files.length === 0) return;
    const file: File = input.files[0];

    // اگر فقط عکس قابل قبول باشد ولی فایل عکس نباشد، پیام بده
    if (this.accept?.includes('image') && !file.type.startsWith('image/')) {
      alert('Nur Bilddateien sind erlaubt!');
      return;
    }

    const reader = new FileReader();
    reader.onload = () => {
      const result = reader.result as string;
      const base64 = result.split(',')[1];

      // پیش‌نمایش فقط برای عکس
      if (file.type.startsWith('image/')) {
        this.fileDataUrl = result;
      } else {
        this.fileDataUrl = null;
      }

      this.fileSelected.emit({
        file,
        field: this.field,
        base64,
        name: file.name,
        type: file.type
      });
    };

    reader.readAsDataURL(file);
  }

  showImagePreview(): boolean {
    return this.isImageType && !!this.fileDataUrl;
  }

}

