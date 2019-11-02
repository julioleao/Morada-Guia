import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Imovel } from '../_models/imovel';
import { ImovelService } from '../_services/imovel.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class ImovelEditResolver implements Resolve<Imovel[]> {
    constructor(private imovelService: ImovelService, private authService: AuthService,
                private router: Router, private alertify: AlertifyService) {}
    resolve(route: ActivatedRouteSnapshot): Observable<Imovel[]> {
        return this.imovelService.getImovel(1).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data from imoveis');
                this.router.navigate(['/imoveis']);
                return of(null);
            })
        );
    }
}
