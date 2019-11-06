/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ImoveisCardUserComponent } from './imoveis-card-user.component';

describe('ImoveisCardUserComponent', () => {
  let component: ImoveisCardUserComponent;
  let fixture: ComponentFixture<ImoveisCardUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImoveisCardUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImoveisCardUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
