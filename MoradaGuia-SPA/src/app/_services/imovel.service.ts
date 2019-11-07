import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Imovel } from '../_models/imovel';


@Injectable({
  providedIn: 'root'
})
export class ImovelService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getImoveis(): Observable<Imovel[]> {
    return this.http.get<Imovel[]>(this.baseUrl + 'imoveis');
  }

  getImovel(id): Observable<Imovel> {
    return this.http.get<Imovel>(this.baseUrl + 'imoveis/' + id);
  }

  updateImovel(id: number, imovel: Imovel) {
    return this.http.put(this.baseUrl + 'imoveis/' + id, imovel);
  }

  setMainPhoto(imovelId: number, id: number) {
    return this.http.post(this.baseUrl + 'imoveis/' + imovelId + '/photos/' + id + '/principal', {});
  }

  deletePhoto(imovelId: number, id: number) {
    return this.http.delete(this.baseUrl + 'imoveis/' + imovelId + '/photos/' + id);
  }

}
