import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { UserProfileComponent } from '../components/user-profile/user-profile.component';

@Injectable()
export class PreventUnsavedProfileChangesGuard
  implements CanDeactivate<UserProfileComponent> {
  canDeactivate(component: UserProfileComponent) {
    if (component.editProfile.dirty) {
      return confirm(
        'You have unsaved changes. If you continue your changes will be lost.'
      );
    }
    return true;
  }
}
