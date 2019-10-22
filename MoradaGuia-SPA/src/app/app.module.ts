import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
<<<<<<< HEAD
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
=======
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
>>>>>>> afbaa48b5f8ab82db5d4ca6c015042a198bd8868

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { NavComponent } from './nav/nav.component';
<<<<<<< HEAD
import { AuthService } from './_services/auth.service';
=======
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
>>>>>>> afbaa48b5f8ab82db5d4ca6c015042a198bd8868

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
<<<<<<< HEAD
      FormsModule,
   ],
   providers: [
      AuthService
=======
      FormsModule
>>>>>>> afbaa48b5f8ab82db5d4ca6c015042a198bd8868
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
