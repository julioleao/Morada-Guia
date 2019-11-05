/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MyimoveisComponent } from './myimoveis.component';

describe('MyimoveisComponent', () => {
  let component: MyimoveisComponent;
  let fixture: ComponentFixture<MyimoveisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyimoveisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyimoveisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
