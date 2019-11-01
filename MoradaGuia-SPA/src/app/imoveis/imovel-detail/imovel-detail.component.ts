import { Component, OnInit } from '@angular/core';
import { Imovel } from 'src/app/_models/imovel';
import { ImovelService } from 'src/app/_services/imovel.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-imovel-detail',
  templateUrl: './imovel-detail.component.html',
  styleUrls: ['./imovel-detail.component.css']
})
export class ImovelDetailComponent implements OnInit {
  imovel: Imovel;
  constructor(private imovelService: ImovelService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imovel = data.imovel;
    });
  }

  // loadImovel() {
  //   this.imovelService.getImovel(this.route.snapshot.params.id).subscribe((imovel: Imovel) => {
  //     this.imovel = imovel;
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }

}
