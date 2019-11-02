import { Component, OnInit } from '@angular/core';
import { Imovel } from 'src/app/_models/imovel';
import { ImovelService } from 'src/app/_services/imovel.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { PathLocationStrategy } from '@angular/common';

@Component({
  selector: 'app-imovel-detail',
  templateUrl: './imovel-detail.component.html',
  styleUrls: ['./imovel-detail.component.css']
})
export class ImovelDetailComponent implements OnInit {
  imovel: Imovel;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private imovelService: ImovelService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imovel = data.imovel;
    });

    this.galleryOptions = [
    {
      width: '500px',
      height: '500px',
      imagePercent: 100,
      thumbnailsColumns: 4,
      imageAnimation: NgxGalleryAnimation.Slide,
      preview: false
    }
  ];
    this.galleryImages = this.getImages();
  }

  getImages() {
    const imageUrls = [];
    for (const foto of this.imovel.fotos) {
      imageUrls.push({
        small: foto.url,
        medium: foto.url,
        big: foto.url
      });
    }
    return imageUrls;
  }

  // loadImovel() {
  //   this.imovelService.getImovel(this.route.snapshot.params.id).subscribe((imovel: Imovel) => {
  //     this.imovel = imovel;
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }

}
