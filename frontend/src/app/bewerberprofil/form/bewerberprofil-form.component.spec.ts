import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BewerberprofilFormComponent } from './bewerberprofil-form.component';

describe('BewerberprofilFormComponent', () => {
  let component: BewerberprofilFormComponent;
  let fixture: ComponentFixture<BewerberprofilFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BewerberprofilFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BewerberprofilFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
