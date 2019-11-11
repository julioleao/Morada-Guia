import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // tslint:disable-next-line: new-parens
  @Output() cancelRegister = new EventEmitter;
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('Registrado com sucesso!');
    }, error => {
      this.alertify.error('Usuário ou senha incorreto');
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
    this.alertify.message('Cancelado');
  }

}
