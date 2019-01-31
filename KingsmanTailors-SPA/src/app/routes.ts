import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { AdminComponent } from './components/admin/admin.component';
import { ValueComponent } from './components/value/value.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { AuthGuard } from './guards/auth.guard';
import { AdminFabricComponent } from './components/admin-fabric/admin-fabric.component';

export const appRoutes: Routes = [
  { path: 'carts', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'admin',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'fabric/:id', component: HomeComponent },
      { path: 'fabric', component: AdminFabricComponent },
      { path: 'front/:id', component: HomeComponent },
      { path: 'front', component: HomeComponent },
      { path: 'lapel/:id', component: HomeComponent },
      { path: 'lapel', component: HomeComponent },
      { path: 'fit/:id', component: HomeComponent },
      { path: 'fit', component: HomeComponent },
      { path: 'style/:id', component: HomeComponent },
      { path: 'style', component: HomeComponent },
      { path: 'type/:id', component: HomeComponent },
      { path: 'type', component: HomeComponent },
      { path: 'tags/:id', component: HomeComponent },
      { path: 'tags', component: HomeComponent },
      { path: 'sizes/:id', component: HomeComponent },
      { path: 'sizes', component: HomeComponent },
      { path: 'suittype/:id', component: HomeComponent },
      { path: 'suittype', component: HomeComponent },
      { path: 'vent/:id', component: HomeComponent },
      { path: 'vent', component: HomeComponent },
      { path: 'suit/detail/:id', component: HomeComponent },
      { path: 'suit/detail', component: HomeComponent },
      { path: 'suit/:id', component: HomeComponent },
      { path: 'suit', component: HomeComponent },
      { path: 'appointment/detail/:id', component: HomeComponent },
      { path: 'appointment/detail', component: HomeComponent },
      { path: 'appointment/:id', component: HomeComponent },
      { path: 'appointment', component: HomeComponent },
      { path: 'home', component: AdminComponent },
      { path: '', redirectTo: 'home', pathMatch: 'full' }
    ]
  },
  { path: 'values', component: ValueComponent, canActivate: [AuthGuard] },
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent }
];
