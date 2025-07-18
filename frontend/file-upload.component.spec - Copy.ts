import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FileUploadComponentComponent } from './file-upload.component.ts';

describe('FileUploadComponentComponent', () => {
  let component: FileUploadComponentComponent;
  let fixture: ComponentFixture<FileUploadComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FileUploadComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FileUploadComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
