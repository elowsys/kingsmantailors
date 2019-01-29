import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ValueComponent } from './components/value/value.component';
import { ValuesService } from './services/values.service';

@NgModule({
  declarations: [AppComponent, ValueComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [ValuesService],
  bootstrap: [AppComponent]
})
export class AppModule {}
