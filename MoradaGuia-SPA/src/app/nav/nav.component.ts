import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { User } from '../_models/user';
import { Imovel } from '../_models/imovel';
import { ImovelFromUserComponent } from '../imoveis/ImovelFromUser/ImovelFromUser.component';
import { ImovelEditComponent } from '../imoveis/imovel-edit/imovel-edit.component';
import { UserEditComponent } from '../user/user-edit/user-edit.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  imoveis: Imovel[];
  model: any = {};
  @Input() imovel: Imovel;
  @Input() user: User;
  imovelFromUser = ImovelFromUserComponent;
  userProfile = UserEditComponent;
  editImovel = ImovelEditComponent;

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imoveis = data['imoveis'];
    });
  }


  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Login realizado com sucesso!!');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/imoveis']);
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }
}
