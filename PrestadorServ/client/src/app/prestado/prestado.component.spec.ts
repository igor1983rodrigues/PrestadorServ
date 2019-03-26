import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrestadoComponent } from './prestado.component';

describe('PrestadoComponent', () => {
  let component: PrestadoComponent;
  let fixture: ComponentFixture<PrestadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrestadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrestadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
