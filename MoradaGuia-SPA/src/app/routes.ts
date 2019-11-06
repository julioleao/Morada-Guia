import { Routes } from '@angular/router';
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
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members', component: MemberListComponent, resolve: {users: MemberListResolver}},
            { path: 'members/:id', component: MemberDetailComponent, resolve: {user: MemberDetailResolver}},
            { path: 'imoveis', component: ImovelListComponent, resolve: {imoveis: ImovelListResolver}},
            { path: 'imoveis/:id', component: ImovelDetailComponent, resolve: {imovel: ImovelDetailResolver}},
            { path: 'imovel/edit', component: ImovelEditComponent,
                resolve: {imovel: ImovelEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            { path: 'messages', component: MessagesComponent},
            { path: 'lists', component: ListsComponent},
        ]
    },
   { path: '**', redirectTo: '', pathMatch: 'full'},
];
