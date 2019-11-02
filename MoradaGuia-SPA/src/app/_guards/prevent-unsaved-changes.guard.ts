import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { ImovelEditComponent } from '../imoveis/imovel-edit/imovel-edit.component';

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<ImovelEditComponent> {
    canDeactivate(component: ImovelEditComponent) {
        if (component.editForm.dirty) {
            return confirm('Suas mudanças não salvas serão perdidas! Deseja continuar mesmo assim?');
        }
        return true;
    }
}
