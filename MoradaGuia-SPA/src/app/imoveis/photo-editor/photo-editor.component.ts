import { Component, Input, OnInit, Output } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { Photo } from 'src/app/_models/photo';
import { AuthService } from 'src/app/_services/auth.service';
import { environment } from 'src/environments/environment';
import { ImovelService } from 'src/app/_services/imovel.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { OutletContext, ActivatedRoute } from '@angular/router';
import { EventEmitter } from '@angular/core';
import { Imovel } from 'src/app/_models/imovel';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css']
})
export class PhotoEditorComponent implements OnInit {
  @Input() photos: Photo[];
  @Input() imovel: Imovel;
  @Output() getImovelPhotoChange = new EventEmitter();
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;
  currentMain: Photo;

  constructor(private route: ActivatedRoute, private authService: AuthService,
              private imovelService: ImovelService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.imovel = data.imovel;
      console.log(this.imovel);
    });
    this.initializeUploader();
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }
  // Verificar rotas da imagem
  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'imoveis/' + this.imovel.id + '/photos',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {file.withCredentials = false; };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const res: Photo = JSON.parse(response);
        const photo = {
          id: res.id,
          url: res.url,
          principal: res.principal
        };
        this.photos.push(photo);
      }
    };
  }

  setMainPhoto(photo: Photo) {
    this.imovelService.setMainPhoto(this.imovel.id, photo.id).subscribe(() => {
      this.currentMain = this.photos.filter(p => p.principal === true)[0];
      this.currentMain.principal = false;
      photo.principal = true;
      this.getImovelPhotoChange.emit(photo.url);
    }, error => {
      this.alertify.error(error);
    });
  }

  deletePhoto(id: number) {
    this.alertify.confirm('Tem certeza que deseja apagar a foto?', () => {
      this.imovelService.deletePhoto(this.imovel.id, id).subscribe(() => {
        this.photos.splice(this.photos.findIndex(p => p.id === id), 1);
        this.alertify.success('Foto apagada com sucesso');
      }, error => {
        this.alertify.error('Falha ao apagar a foto');
      });
    });
  }
}
