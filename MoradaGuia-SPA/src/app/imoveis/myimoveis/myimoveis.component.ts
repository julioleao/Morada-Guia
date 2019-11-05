import { Component, OnInit } from '@angular/core';
import { Imovel } from '../../_models/imovel';
import { ImovelService } from '../../_services/imovel.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-myimoveis',
  templateUrl: './myimoveis.component.html',
  styleUrls: ['./myimoveis.component.css']
})
export class MyimoveisComponent implements OnInit {
  userId: any;
  imoveis: Imovel[];
  arrImoveis: Imovel[] = new Array();

  constructor(private imovelService: ImovelService, private alertify: AlertifyService, private route: ActivatedRoute,
              private authService: AuthService) { }

  ngOnInit() {
    let pos = 0;
    this.userId = this.authService.decodedToken.nameid;

    this.route.data.subscribe(data => {
      this.imoveis = data.imoveis;

      for (let i = 0; i < this.imoveis.length; i++) {
        if (this.imoveis[i].id == this.userId) {
          this.arrImoveis[pos] = this.imoveis[i];
          pos++;
        }
      }

      this.imoveis = this.arrImoveis;
    });
  }

}
