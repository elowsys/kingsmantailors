import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ValueComponent } from './components/value/value.component';
import { ValuesService } from './services/values.service';
import { AuthService } from './services/auth.service';
import { NavComponent } from './components/nav/nav.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ShoppingCartMiniComponent } from './components/shopping-cart-mini/shopping-cart-mini.component';
import { RegisterComponent } from './components/register/register.component';
import { ErrorInterceptorProvider } from './services/error.interceptor';
import { AlertifyService } from './services/alertify.service';
import { BsDropdownModule } from 'ngx-bootstrap';

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
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot([
      // { path: '', component: WorkareaComponent },
      // { path: ':id', component: DeviceComponent },
      // {
      //   path: 'admin/audiovisual/:id',
      //   component: AdminAudioVisualComponent
      // },
      // {
      //   path: 'admin/audiovisual',
      //   component: AdminAudioVisualComponent
      // },
      // {
      //   path: 'admin/device/:id',
      //   component: AdminDeviceComponent
      // },
      // {
      //   path: 'admin/device',
      //   component: AdminDeviceComponent
      // },
      // {
      //   path: 'admin/devicetype/:id',
      //   component: AdminDeviceTypeComponent
      // },
      // {
      //   path: 'admin/devicetype',
      //   component: AdminDeviceTypeComponent
      // },
      // {
      //   path: 'admin/netmedia',
      //   component: AdminNetmediaComponent
      // },
      // {
      //   path: 'admin/netmedia/:id',
      //   component: AdminNetmediaComponent
      // },
      // {
      //   path: 'admin/storage/:id',
      //   component: AdminHardwareStorageComponent
      // },
      // {
      //   path: 'admin/storage',
      //   component: AdminHardwareStorageComponent
      // },
      // {
      //   path: 'admin/hardware/:id',
      //   component: AdminHardwareComponent
      // },
      // {
      //   path: 'admin/hardware',
      //   component: AdminHardwareComponent
      // },
      // {
      //   path: 'admin/service/nodes/:id',
      //   component: AdminServiceNodeComponent
      // },
      // {
      //   path: 'admin/service/nodes',
      //   component: AdminServiceNodeComponent
      // },
      // {
      //   path: 'admin/service/status/:id',
      //   component: AdminServiceStatusComponent
      // },
      // {
      //   path: 'admin/service/status',
      //   component: AdminServiceStatusComponent
      // },
      // {
      //   path: 'admin/service/:id',
      //   component: AdminServiceComponent
      // },
      // {
      //   path: 'admin/service',
      //   component: AdminServiceComponent
      // },
      // {
      //   path: 'admin/nodes/:id',
      //   component: AdminNodeComponent
      // },
      // {
      //   path: 'admin/nodes',
      //   component: AdminNodeComponent
      // },
      {
        path: '',
        component: HomeComponent
      },
      {
        path: 'home',
        component: HomeComponent
      },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      },
      {
        path: 'values/:id',
        component: ValueComponent
      },
      {
        path: 'values',
        component: ValueComponent
      },
      {
        path: '**',
        component: NotFoundComponent
      }
    ])
  ],
  providers: [
    ValuesService,
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
