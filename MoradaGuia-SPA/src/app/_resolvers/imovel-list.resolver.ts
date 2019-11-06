import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Imovel } from '../_models/imovel';
import { ImovelService } from '../_services/imovel.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ImovelListResolver implements Resolve<Imovel[]> {
    constructor(private imovelService: ImovelService, private router: Router, private alertify: AlertifyService) {}
    resolve(route: ActivatedRouteSnapshot): Observable<Imovel[]> {
        console.log('resolver');
        return this.imovelService.getImoveis().pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data list');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
