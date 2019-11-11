import { Component, OnInit, Input } from '@angular/core';
import { Imovel } from 'src/app/_models/imovel';

@Component({
  selector: 'app-imoveis-card-user',
  templateUrl: './imoveis-card-user.component.html',
  styleUrls: ['./imoveis-card-user.component.css']
})
export class ImoveisCardUserComponent implements OnInit {
  @Input() imovel: Imovel;

  constructor() { }

  ngOnInit() {
  }

}
