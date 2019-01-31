import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BsDropdownModule } from 'ngx-bootstrap';

import { appRoutes } from './routes';
import { AuthGuard } from './guards/auth.guard';

import { ValuesService } from './services/values.service';
import { AuthService } from './services/auth.service';
import { ErrorInterceptorProvider } from './services/error.interceptor';
import { AlertifyService } from './services/alertify.service';
import { HeaderService } from './services/header.service';

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
import { AdminFabricComponent } from './components/admin-fabric/admin-fabric.component';

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
    AdminFabricComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    ValuesService,
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
    HeaderService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
