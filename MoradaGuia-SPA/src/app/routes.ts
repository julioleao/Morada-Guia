import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ImovelListComponent } from './imoveis/imovel-list/imovel-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { ImovelDetailComponent } from './imoveis/imovel-detail/imovel-detail.component';
import { ImovelDetailResolver } from './_resolvers/imovel-detail.resolver';
import { ImovelListResolver } from './_resolvers/imovel-list.resolver';
import { ImovelEditComponent } from './imoveis/imovel-edit/imovel-edit.component';
import { ImovelEditResolver } from './_resolvers/imovel-edit.resolver';
import { ImovelMyListResolver } from './_resolvers/imovel-mylist.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
<<<<<<< HEAD
import { ImovelListToEditComponent } from './imoveis/imovel-listToEdit/imovel-listToEdit.component';
=======
import { MyimoveisComponent } from './imoveis/myimoveis/myimoveis.component';
>>>>>>> 2b190af7b8fa6854e36287da9b12874b691ed87e

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'imoveis', component: ImovelListComponent, resolve: {imoveis: ImovelListResolver}},
            { path: 'myimoveis', component: MyimoveisComponent, resolve: {imoveis: ImovelMyListResolver}},
            { path: 'imoveis/:id', component: ImovelDetailComponent, resolve: {imovel: ImovelDetailResolver}},
<<<<<<< HEAD
            { path: 'imovel/edit', component: ImovelListToEditComponent,
                resolve: {imovel: ImovelListResolver}, canDeactivate: [PreventUnsavedChanges]},
=======
            { path: 'imovel/edit/:id', component: ImovelEditComponent,
                resolve: {imovel: ImovelEditResolver}, canDeactivate: [PreventUnsavedChanges]},
>>>>>>> 2b190af7b8fa6854e36287da9b12874b691ed87e
            { path: 'messages', component: MessagesComponent},
            { path: 'lists', component: ListsComponent},
        ]
    },
   { path: '**', redirectTo: '', pathMatch: 'full'},
];
