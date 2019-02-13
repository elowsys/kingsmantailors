import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { AdminSystemUserEditComponent } from '../components/admin-system-user-edit/admin-system-user-edit.component';

@Injectable()
export class PreventUnsavedChangesGuard
  implements CanDeactivate<AdminSystemUserEditComponent> {
  canDeactivate(component: AdminSystemUserEditComponent) {
    if (component.editForm.dirty) {
      return confirm(
        'You have unsaved changes. If you continue your changes will be lost.'
      );
    }
    return true;
  }
}
