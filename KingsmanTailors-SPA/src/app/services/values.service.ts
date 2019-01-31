import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class ValuesService extends DataService {
  constructor(http: HttpClient) {
    super(http, '/values');
  }
}
