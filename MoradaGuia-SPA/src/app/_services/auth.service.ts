import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
<<<<<<< HEAD
import {map} from 'rxjs/operators';
=======
import { map } from 'rxjs/operators';

>>>>>>> afbaa48b5f8ab82db5d4ca6c015042a198bd8868
@Injectable({
  providedIn: 'root'
})
export class AuthService {
<<<<<<< HEAD
  baseUrl = 'http://localhost:5000/api/auth/';
=======
baseUrl = 'http://localhost:5000/api/auth';

>>>>>>> afbaa48b5f8ab82db5d4ca6c015042a198bd8868
constructor(private http: HttpClient) { }

login(model: any) {
  return this.http.post(this.baseUrl + 'login', model)
  .pipe(
<<<<<<< HEAD
    map((response: any) => {
=======
    map((response: any) =>{
>>>>>>> afbaa48b5f8ab82db5d4ca6c015042a198bd8868
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token);
      }
    })
  );
}

}
