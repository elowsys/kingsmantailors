import { Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { AdminGuard } from './guards/admin.guard';
import { PreventUnsavedChangesGuard } from './guards/prevent-unsaved-changes.guard';
import { PreventUnsavedProfileChangesGuard } from './guards/prevent-unsaved-profile-changes.guard';

import { RoleResolver } from './resolvers/role.resolver';
import { UserDetailResolver } from './resolvers/user-detail.resolver';
import { UserListResolver } from './resolvers/user-list.resolver';
import { UserRoleResolver } from './resolvers/user-role.resolver';

import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { AdminComponent } from './components/admin/admin.component';
import { ValueComponent } from './components/value/value.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { AdminStyleComponent } from './components/admin-style/admin-style.component';
import { AdminTypeComponent } from './components/admin-type/admin-type.component';
import { AdminSalesTagsComponent } from './components/admin-sales-tags/admin-sales-tags.component';
import { AdminSuitSizeComponent } from './components/admin-suit-size/admin-suit-size.component';
import { AdminSuitTypeComponent } from './components/admin-suit-type/admin-suit-type.component';
import { AdminSuitVentComponent } from './components/admin-suit-vent/admin-suit-vent.component';
import { AdminSuitLabelComponent } from './components/admin-suit-label/admin-suit-label.component';
import { AdminSuitLapelComponent } from './components/admin-suit-lapel/admin-suit-lapel.component';
import { AdminSuitFrontComponent } from './components/admin-suit-front/admin-suit-front.component';
import { AdminSuitFabricComponent } from './components/admin-suit-fabric/admin-suit-fabric.component';
import { AdminSuitFitComponent } from './components/admin-suit-fit/admin-suit-fit.component';
import { AdminSuitDetailComponent } from './components/admin-suit-detail/admin-suit-detail.component';
import { AdminSuitComponent } from './components/admin-suit/admin-suit.component';
import { AdminAppointmentDetailComponent } from './components/admin-appointment-detail/admin-appointment-detail.component';
import { AdminAppointmentComponent } from './components/admin-appointment/admin-appointment.component';
import { AdminSystemUsersComponent } from './components/admin-system-users/admin-system-users.component';
import { AdminSystemUserDetailComponent } from './components/admin-system-user-detail/admin-system-user-detail.component';
import { AdminSystemUserEditComponent } from './components/admin-system-user-edit/admin-system-user-edit.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { UserProfileResolver } from './resolvers/user-profile.resolver';

export const appRoutes: Routes = [
  { path: 'cart', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'admin',
    runGuardsAndResolvers: 'always',
    canActivate: [AdminGuard],
    children: [
      {
        path: 'suit/fabric/:id',
        component: AdminSuitFabricComponent,
        data: {
          breadcrumb: 'Home'
        }
      },
      {
        path: 'suit/fabric',
        component: AdminSuitFabricComponent
      },
      {
        path: 'suit/front/:id',
        component: AdminSuitFrontComponent
      },
      { path: 'suit/front', component: AdminSuitFrontComponent },
      {
        path: 'suit/label/:id',
        component: AdminSuitLabelComponent
      },
      { path: 'suit/label', component: AdminSuitLabelComponent },
      {
        path: 'suit/lapel/:id',
        component: AdminSuitLapelComponent
      },
      { path: 'suit/lapel', component: AdminSuitLapelComponent },
      { path: 'suit/fit/:id', component: AdminSuitFitComponent },
      { path: 'suit/fit', component: AdminSuitFitComponent },
      { path: 'suit/style/:id', component: AdminStyleComponent },
      { path: 'suit/style', component: AdminStyleComponent },
      { path: 'suit/type/:id', component: AdminTypeComponent },
      { path: 'suit/type', component: AdminTypeComponent },
      {
        path: 'suit/sizes/:id',
        component: AdminSuitSizeComponent
      },
      { path: 'suit/sizes', component: AdminSuitSizeComponent },
      {
        path: 'suit/suittype/:id',
        component: AdminSuitTypeComponent
      },
      {
        path: 'suit/suittype',
        component: AdminSuitTypeComponent
      },
      {
        path: 'suit/vent/:id',
        component: AdminSuitVentComponent
      },
      { path: 'suit/vent', component: AdminSuitVentComponent },
      {
        path: 'suit/detail/:id',
        component: AdminSuitDetailComponent
      },
      {
        path: 'suit/detail',
        component: AdminSuitDetailComponent
      },
      { path: 'suit/:id', component: AdminSuitComponent },
      { path: 'suit', component: AdminSuitComponent },
      { path: 'tags/:id', component: AdminSalesTagsComponent },
      { path: 'tags', component: AdminSalesTagsComponent },
      {
        path: 'appointment/detail/:id',
        component: AdminAppointmentDetailComponent
      },
      {
        path: 'appointment/detail',
        component: AdminAppointmentDetailComponent
      },
      {
        path: 'appointment/:id',
        component: AdminAppointmentComponent
      },
      {
        path: 'appointment',
        component: AdminAppointmentComponent
      },
      {
        path: 'system/users/:userId',
        component: AdminSystemUserDetailComponent,
        resolve: {
          user: UserDetailResolver,
          role: UserRoleResolver
        }
      },
      {
        path: 'system/users/edit/:userId',
        component: AdminSystemUserEditComponent,
        resolve: {
          user: UserDetailResolver,
          roles: RoleResolver
        },
        canDeactivate: [PreventUnsavedChangesGuard]
      },
      {
        path: 'system/users',
        component: AdminSystemUsersComponent,
        resolve: { users: UserListResolver }
      },
      { path: 'home', component: AdminComponent },
      { path: '', redirectTo: 'home', pathMatch: 'full' }
    ]
  },
  {
    path: 'values',
    component: ValueComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'profile/:userid',
    component: UserProfileComponent,
    canActivate: [AuthGuard],
    resolve: {
      user: UserProfileResolver,
      role: RoleResolver
    },
    canDeactivate: [PreventUnsavedProfileChangesGuard]
  },
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent }
];
