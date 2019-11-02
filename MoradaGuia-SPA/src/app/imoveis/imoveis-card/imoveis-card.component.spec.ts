/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ImoveisCardComponent } from './imoveis-card.component';

describe('ImoveisCardComponent', () => {
  let component: ImoveisCardComponent;
  let fixture: ComponentFixture<ImoveisCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImoveisCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImoveisCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
