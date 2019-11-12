import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Imovel } from 'src/app/_models/imovel';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-register-imovel',
  templateUrl: './register-imovel.component.html',
  styleUrls: ['./register-imovel.component.css']
})
export class RegisterImovelComponent implements OnInit {
  imovel: Imovel;
  registerForm: FormGroup;

  constructor(private router: Router, private alertify: AlertifyService,
              private authService: AuthService, private fb: FormBuilder) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      tipo: ['', Validators.required],
      rua: ['', Validators.required],
      numero: ['', Validators.required],
      bairro: ['', Validators.required],
      valor: ['', Validators.required],
      qtdQuarto: ['', Validators.required],
      qtdBanheiro: ['', Validators.required],
      garagem: ['', Validators.required],
      userId: [this.authService.decodedToken.nameid, Validators.required]
    });
  }

  registerImovel() {
    if (this.registerForm.valid) {
      this.imovel = Object.assign({}, this.registerForm.value);
      this.authService.registerImovel(this.imovel).subscribe(() => {
        this.alertify.success('Imovel registrado com sucesso');
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  cancel() {
    this.router.navigate(['/imoveis']);
  }

}
