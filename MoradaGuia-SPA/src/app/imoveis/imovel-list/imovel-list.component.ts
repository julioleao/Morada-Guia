import { Component, OnInit, Input } from '@angular/core';
import { Imovel } from '../../_models/imovel';
import { ImovelService } from '../../_services/imovel.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { PaginatedResult, Pagination } from 'src/app/_models/pagination';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-imovel-list',
  templateUrl: './imovel-list.component.html',
  styleUrls: ['./imovel-list.component.css']
})
export class ImovelListComponent implements OnInit {
  imoveis: Imovel[];
  imovel: Imovel = JSON.parse(localStorage.getItem('imovel'));
  tipoList = [{value: 'Casa', display: 'Casas'}, {value: 'Pensionato', display: 'Pensionatos'}];
  imovelParams: any = {};
  pagination: Pagination;

  constructor(private imovelService: ImovelService, private alertify: AlertifyService, private route: ActivatedRoute,
              private authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imoveis = data.imoveis.result;
      this.pagination = data.imoveis.pagination;
    });

    this.imovelParams.valorMin = 0;
    this.imovelParams.valorMax = 5000;
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadImoveis();
  }

  resetFilters() {
    this.imovelParams.tipo = 'undefined';
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
  }
}
