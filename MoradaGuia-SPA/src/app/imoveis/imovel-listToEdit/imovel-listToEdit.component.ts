import { Component, OnInit } from '@angular/core';
import { Imovel } from 'src/app/_models/imovel';
import { ImovelService } from 'src/app/_services/imovel.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'app-imovel-listToEdit',
  templateUrl: './imovel-listToEdit.component.html',
  styleUrls: ['./imovel-listToEdit.component.css']
})
export class ImovelListToEditComponent implements OnInit {
  imoveis: Imovel[];

  constructor(private imovelService: ImovelService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imoveis = data['imoveis'];
    });
  }
}
