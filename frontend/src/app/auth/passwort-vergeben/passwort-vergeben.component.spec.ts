import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PasswortVergebenComponent } from './passwort-vergeben.component';

describe('PasswortVergebenComponent', () => {
  let component: PasswortVergebenComponent;
  let fixture: ComponentFixture<PasswortVergebenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PasswortVergebenComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PasswortVergebenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
