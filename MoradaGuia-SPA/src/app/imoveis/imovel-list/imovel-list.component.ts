import { Component, OnInit } from '@angular/core';
import { Imovel } from '../../_models/imovel';
import { ImovelService } from '../../_services/imovel.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-imovel-list',
  templateUrl: './imovel-list.component.html',
  styleUrls: ['./imovel-list.component.css']
})
export class ImovelListComponent implements OnInit {
  userId: any;
  imoveis: Imovel[];
  arrImoveis: Imovel[] = new Array();

  constructor(private imovelService: ImovelService, private alertify: AlertifyService, private route: ActivatedRoute,
              private authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imoveis = data.imoveis;
    });
  }

  // loadImoveis() {
  //   this.imovelService.getImoveis().subscribe((imoveis: Imovel[]) => {
  //     this.imoveis = imoveis;
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }
}
