import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Imovel } from 'src/app/_models/imovel';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-imovel-edit',
  templateUrl: './imovel-edit.component.html',
  styleUrls: ['./imovel-edit.component.css']
})
export class ImovelEditComponent implements OnInit {
  @ViewChild('editForm', {static: true}) editForm: NgForm;
  imovel: Imovel;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  constructor(private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imovel = data['imovel'];
      console.log(this.imovel);
    });
  }

  updateImovel() {
    console.log(this.imovel);
    this.alertify.success('Atualizado com sucesso');
    this.editForm.reset(this.imovel);
  }

}
