import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ImovelListComponent } from './imoveis/imovel-list/imovel-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'imoveis', component: ImovelListComponent},
            { path: 'messages', component: MessagesComponent},
            { path: 'lists', component: ListsComponent},
        ]
    },
   { path: '**', redirectTo: '', pathMatch: 'full'},
];
