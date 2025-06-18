import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StadtFormComponent } from './stadt-form.component';

describe('StadtFormComponent', () => {
  let component: StadtFormComponent;
  let fixture: ComponentFixture<StadtFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StadtFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StadtFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
