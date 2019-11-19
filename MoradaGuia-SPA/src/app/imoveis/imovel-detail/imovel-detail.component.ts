import { Component, OnInit, Input } from '@angular/core';
import { Imovel } from 'src/app/_models/imovel';
import { ImovelService } from 'src/app/_services/imovel.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { PathLocationStrategy } from '@angular/common';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-imovel-detail',
  templateUrl: './imovel-detail.component.html',
  styleUrls: ['./imovel-detail.component.css']
})
export class ImovelDetailComponent implements OnInit {
  imovel: Imovel;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  user: User;

  constructor(private imovelService: ImovelService, private alertify: AlertifyService,
              private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imovel = data.imovel;
    });
    this.userService.getUser(this.imovel.userId).subscribe((user: User) => {
      this.user = user;
    });
    // console.log(this.imovel.userId);
    // console.log(this.user.telefone);
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
