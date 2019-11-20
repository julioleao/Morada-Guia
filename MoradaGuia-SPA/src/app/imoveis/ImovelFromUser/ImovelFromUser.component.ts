import { Component, OnInit, Input } from '@angular/core';
import { ImovelService } from 'src/app/_services/imovel.service';
import { AuthService } from 'src/app/_services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { Imovel } from 'src/app/_models/imovel';
import { User } from 'src/app/_models/user';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-ImovelFromUser',
  templateUrl: './ImovelFromUser.component.html',
  styleUrls: ['./ImovelFromUser.component.css']
})
export class ImovelFromUserComponent implements OnInit {
  imovel: Imovel[];
  imoveis: Imovel;
  user: User;
  alertify: any;
  constructor(private authService: AuthService, private imovelService: ImovelService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.user = this.authService.decodedToken.nameid;
    this.imovelService.getImoveisFromUser(this.authService.decodedToken.nameid).subscribe((imovel: Imovel[]) => {
      this.imovel = imovel;
    }, error => {
      this.alertify.error(error);
    });
  }


}
