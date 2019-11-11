import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-register-imovel',
  templateUrl: './register-imovel.component.html',
  styleUrls: ['./register-imovel.component.css']
})
export class RegisterImovelComponent implements OnInit {
  model: any = {};

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
  }

  registerImovel() {
    console.log(this.authService.registerImovel(this.model));
    this.authService.registerImovel(this.model).subscribe(() => {
      console.log('Imovel registrado com sucesso');
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    this.router.navigate(['/home']);
  }

}
