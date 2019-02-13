import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ValuesService extends DataService {
  constructor(http: HttpClient) {
    super(http, 'values');
  }

  getValues(): Observable<[]> {
    return this.getAll<[]>();
  }
}
