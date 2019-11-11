import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../_models/user';
import { Imovel } from '../_models/imovel';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  imoveis: Imovel[];
  model: any = {};
  @Input() user: User;

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
