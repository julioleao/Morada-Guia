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

}
