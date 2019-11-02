/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ImovelListComponent } from './imovel-list.component';

describe('ImovelListComponent', () => {
  let component: ImovelListComponent;
  let fixture: ComponentFixture<ImovelListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImovelListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImovelListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
