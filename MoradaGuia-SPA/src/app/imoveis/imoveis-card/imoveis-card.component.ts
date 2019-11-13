import { Component, OnInit, Input } from '@angular/core';
import { Imovel } from 'src/app/_models/imovel';

@Component({
  selector: 'app-imoveis-card',
  templateUrl: './imoveis-card.component.html',
  styleUrls: ['./imoveis-card.component.css']
})
export class ImoveisCardComponent implements OnInit {
  @Input() imovel: Imovel;

  constructor() { }

  ngOnInit() {
  }

}
