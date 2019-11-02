/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ImovelEditComponent } from './imovel-edit.component';

describe('ImovelEditComponent', () => {
  let component: ImovelEditComponent;
  let fixture: ComponentFixture<ImovelEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImovelEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImovelEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
