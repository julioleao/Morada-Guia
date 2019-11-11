import { Component, OnInit, ViewChild, HostListener, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Imovel } from 'src/app/_models/imovel';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { NgForm } from '@angular/forms';
import { ImovelService } from 'src/app/_services/imovel.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-imovel-edit',
  templateUrl: './imovel-edit.component.html',
  styleUrls: ['./imovel-edit.component.css']
})
export class ImovelEditComponent implements OnInit {
  @ViewChild('editForm', {static: true}) editForm: NgForm;
  @Output() getImovelEdit = new EventEmitter();
  imovel: Imovel;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  constructor(private route: ActivatedRoute, private alertify: AlertifyService,
              private imovelService: ImovelService, private authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imovel = data.imovel;
    });
  }

  updateImovel() {
    this.imovelService.updateImovel(this.imovel).subscribe(next => {
      this.alertify.success('Atualizado com sucesso');
      this.editForm.reset(this.imovel);
    }, error => {
      this.alertify.error(error);
    });
  }

  updateMainPhoto(photoUrl) {
    this.imovel.urlFoto = photoUrl;
  }

}
