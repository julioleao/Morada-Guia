import { Component, OnInit } from '@angular/core';
import { Imovel } from '../../_models/imovel';
import { ImovelService } from '../../_services/imovel.service';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-imovel-list',
  templateUrl: './imovel-list.component.html',
  styleUrls: ['./imovel-list.component.css']
})
export class ImovelListComponent implements OnInit {

  imoveis: Imovel[];

  constructor(private imovelService: ImovelService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadImoveis();
  }


  loadImoveis() {
    this.imovelService.getImoveis().subscribe((imoveis: Imovel[]) => {
      this.imoveis = imoveis;
    }, error => {
      this.alertify.error(error);
    });
  }
}
