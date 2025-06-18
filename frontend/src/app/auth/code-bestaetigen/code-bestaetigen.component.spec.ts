import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CodeBestaetigenComponent } from './code-bestaetigen.component';

describe('CodeBestaetigenComponent', () => {
  let component: CodeBestaetigenComponent;
  let fixture: ComponentFixture<CodeBestaetigenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CodeBestaetigenComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CodeBestaetigenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
