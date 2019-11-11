import { Component, OnInit } from '@angular/core';
import { Imovel } from '../../_models/imovel';
import { ImovelService } from '../../_services/imovel.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { PaginatedResult, Pagination } from 'src/app/_models/pagination';

@Component({
  selector: 'app-imovel-list',
  templateUrl: './imovel-list.component.html',
  styleUrls: ['./imovel-list.component.css']
})
export class ImovelListComponent implements OnInit {
  imoveis: Imovel[];
  /* imovel: Imovel = JSON.parse(localStorage.getItem('imovel'));
  tipo = [{value: 'casa', display: 'Casa'}, {value: 'pensionato', display: 'Pensionato'},
          {value: 'apartamento', display: 'Apartamento'}, {value: 'quitinete', display: 'Quitinete'}];
  imovelParams: any = {};
  pagination: Pagination; */

  constructor(private imovelService: ImovelService, private alertify: AlertifyService, private route: ActivatedRoute,
              private authService: AuthService) { }

  ngOnInit() {
    console.log('component');
    this.route.data.subscribe(data => {
      this.imoveis = data.imoveis; // .result;
      // this.pagination = data.imoveis.pagination;
    });

    /* this.imovelParams.tipo = this.imovel.tipo === 'casa' ? 'pensionato'
    : 'casa' ? 'apartamento'
    : 'casa' ? 'apartamento'
    : 'casa' ? 'quitinete'
    : 'casa';
    this.imovelParams.valorMin = 0;
    this.imovelParams.valorMax = 5000; */
  }

  /* pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadImoveis();
  }

  resetFilters() {
    this.imovelParams.tipo = this.imovel.tipo === 'casa' ? 'pensionato'
    : 'casa' ? 'apartamento'
    : 'casa' ? 'apartamento'
    : 'casa' ? 'quitinete'
    : 'casa';
    this.imovelParams.valorMin = 0;
    this.imovelParams.valorMax = 5000;
    this.loadImoveis();
  }

  loadImoveis() {
    this.imovelService
      .getImoveis(this.pagination.currentPage, this.pagination.itemsPerPage, this.imovelParams)
      .subscribe(
        (res: PaginatedResult<Imovel[]>) => {
          this.imoveis = res.result;
          this.pagination = res.pagination;
        },
        error => {
          this.alertify.error(error);
        }
      );
  } */
}
