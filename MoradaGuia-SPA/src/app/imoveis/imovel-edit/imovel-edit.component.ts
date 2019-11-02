import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Imovel } from 'src/app/_models/imovel';

@Component({
  selector: 'app-imovel-edit',
  templateUrl: './imovel-edit.component.html',
  styleUrls: ['./imovel-edit.component.css']
})
export class ImovelEditComponent implements OnInit {
  imovel: Imovel;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imovel = data['imovel'];
      console.log(this.imovel);
    });
  }

}
