import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Imovel } from '../_models/imovel';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ImovelService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getImoveis(page?, itemsPerPage?): Observable<PaginatedResult<Imovel[]>> {
    const paginatedResult: PaginatedResult<Imovel[]> = new PaginatedResult<Imovel[]>();

    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http.get<Imovel[]>(this.baseUrl + 'imoveis', { observe: 'response', params })
    .pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
  }
  /*
  getImoveis(page?, itemsPerPage?, imovelParams?): Observable<PaginatedResult<Imovel[]>> {
    const paginatedResult: PaginatedResult<Imovel[]> = new PaginatedResult<Imovel[]>();

    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    if (imovelParams != null) {
      params = params.append('valorMin', imovelParams.valorMin);
      params = params.append('valorMax', imovelParams.valorMax);
      params = params.append('tipo', imovelParams.tipo);
    }

    return this.http.get<Imovel[]>(this.baseUrl + 'imoveis', { observe: 'response', params })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }
  */
  getImovel(id: number): Observable<Imovel> {
    return this.http.get<Imovel>(this.baseUrl + 'imoveis/' + id);
  }

  updateImovel(imovel: Imovel) {
    return this.http.put(this.baseUrl + 'imoveis/' + imovel.id, imovel);
  }

  setMainPhoto(imovelId: number, id: number) {
    return this.http.post(this.baseUrl + 'imoveis/' + imovelId + '/photos/' + id + '/principal', {});
  }

  deletePhoto(imovelId: number, id: number) {
    return this.http.delete(this.baseUrl + 'imoveis/' + imovelId + '/photos/' + id);
  }

  getImoveisFromUser(userId: number): Observable<Imovel[]> {
    return this.http.get<Imovel[]>(this.baseUrl + 'imoveis/user/' + userId);
  }

  deleteImovel(imovelId: number) {
    return this.http.delete(this.baseUrl + 'imoveis/' + imovelId);
  }

}
