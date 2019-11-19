import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ImovelListComponent } from './imoveis/imovel-list/imovel-list.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { ImovelDetailComponent } from './imoveis/imovel-detail/imovel-detail.component';
import { ImovelDetailResolver } from './_resolvers/imovel-detail.resolver';
import { ImovelListResolver } from './_resolvers/imovel-list.resolver';
import { ImovelEditComponent } from './imoveis/imovel-edit/imovel-edit.component';
import { ImovelEditResolver } from './_resolvers/imovel-edit.resolver';
import { ImovelMyListResolver } from './_resolvers/imovel-mylist.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { RegisterImovelComponent } from './register/register-imovel/register-imovel.component';
import { ImovelFromUserResolver } from './_resolvers/imovel-from-user.resolver';
import { ImovelFromUserComponent } from './imoveis/ImovelFromUser/ImovelFromUser.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/user-edit.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        children: [
            { path: 'imoveis', component: ImovelListComponent,
                resolve: {imoveis: ImovelListResolver}},
            { path: 'imoveis/:id', component: ImovelDetailComponent,
                resolve: {imovel: ImovelDetailResolver}},
            { path: 'imoveis/user/:id', component: ImovelFromUserComponent,
                resolve: {imoveis: ImovelFromUserResolver}},
            { path: 'imovel/edit/:id', component: ImovelEditComponent,
                resolve: {imovel: ImovelEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            { path: 'users/:id', component: UserEditComponent,
            resolve: {user: UserEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            { path: 'lists', component: ListsComponent},
            { path: 'register-imovel', component: RegisterImovelComponent},
        ]
    },
   { path: '**', redirectTo: '', pathMatch: 'full'},
];
