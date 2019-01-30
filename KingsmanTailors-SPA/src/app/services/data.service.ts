import { Injectable } from '@angular/core';
import { THROW_IF_NOT_FOUND } from '@angular/core/src/di/injector';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private _baseUrl = 'http://localhost:5000/api';
  constructor(public http: HttpClient, private _pathPrefix: string) {}

  get BaseUrl() {
    return this._baseUrl + this._pathPrefix;
  }

  getAll() {
    return this.http.get(this.BaseUrl);
  }

  get(id: number) {
    return this.http.get(this.BaseUrl + '/' + id);
  }
}
