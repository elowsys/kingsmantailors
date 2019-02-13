import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from 'ngx-gallery';
import { FileUploadModule } from 'ng2-file-upload';

import { appRoutes } from './routes';
import { AuthGuard } from './guards/auth.guard';
import { PreventUnsavedChangesGuard } from './guards/prevent-unsaved-changes.guard';
import { PreventUnsavedProfileChangesGuard } from './guards/prevent-unsaved-profile-changes.guard';

import { RoleResolver } from './resolvers/role.resolver';
import { UserDetailResolver } from './resolvers/user-detail.resolver';
import { UserListResolver } from './resolvers/user-list.resolver';
import { UserRoleResolver } from './resolvers/user-role.resolver';
import { UserProfileResolver } from './resolvers/user-profile.resolver';

import { ValuesService } from './services/values.service';
import { AuthService } from './services/auth.service';
import { ErrorInterceptorProvider } from './services/error.interceptor';
import { AlertifyService } from './services/alertify.service';
import { HeaderService } from './services/header.service';
import { UserService } from './services/user.service';

import { AppComponent } from './app.component';
import { ValueComponent } from './components/value/value.component';
import { NavComponent } from './components/nav/nav.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { HomeComponent } from './components/home/home.component';
import { ShoppingCartMiniComponent } from './components/shopping-cart-mini/shopping-cart-mini.component';
import { RegisterComponent } from './components/register/register.component';
import { AdminComponent } from './components/admin/admin.component';
import { CartMiniComponent } from './components/cart-mini/cart-mini.component';
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
import { UserCardComponent } from './components/user-card/user-card.component';
import { AdminSystemUserDetailComponent } from './components/admin-system-user-detail/admin-system-user-detail.component';
import { AdminSystemUserEditComponent } from './components/admin-system-user-edit/admin-system-user-edit.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { BreadcrumbsComponent } from './components/breadcrumbs/breadcrumbs.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}
@NgModule({
  declarations: [
    AppComponent,
    ValueComponent,
    NavComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    NotFoundComponent,
    HomeComponent,
    ShoppingCartMiniComponent,
    RegisterComponent,
    AdminComponent,
    CartMiniComponent,
    AdminStyleComponent,
    AdminTypeComponent,
    AdminSalesTagsComponent,
    AdminSuitSizeComponent,
    AdminSuitTypeComponent,
    AdminSuitVentComponent,
    AdminSuitLabelComponent,
    AdminSuitLapelComponent,
    AdminSuitFrontComponent,
    AdminSuitFabricComponent,
    AdminSuitFitComponent,
    AdminSuitDetailComponent,
    AdminSuitComponent,
    AdminAppointmentDetailComponent,
    AdminAppointmentComponent,
    AdminSystemUsersComponent,
    UserCardComponent,
    AdminSystemUserDetailComponent,
    AdminSystemUserEditComponent,
    UserProfileComponent,
    BreadcrumbsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    NgxGalleryModule,
    FileUploadModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      }
    })
  ],
  providers: [
    ValuesService,
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
    AuthGuard,
    HeaderService,
    UserService,
    UserDetailResolver,
    UserListResolver,
    UserRoleResolver,
    UserProfileResolver,
    RoleResolver,
    PreventUnsavedChangesGuard,
    PreventUnsavedProfileChangesGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
