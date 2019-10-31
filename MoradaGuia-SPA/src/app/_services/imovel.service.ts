import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Imovel } from '../_models/imovel';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class ImovelService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getImoveis(): Observable<Imovel[]> {
    return this.http.get<Imovel[]>(this.baseUrl + 'imoveis', httpOptions);
  }

  getImovel(id): Observable<Imovel> {
    return this.http.get<Imovel>(this.baseUrl + 'imoveis/' + id, httpOptions);
  }

}
