import { Injectable } from '@angular/core';
import { THROW_IF_NOT_FOUND } from '@angular/core/src/di/injector';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private _parentUrl = 'http://localhost:5000/api';
  constructor(private _http: HttpClient, private _pathPrefix: string) {}

  private get PathUrl() {
    return this._parentUrl + this._pathPrefix;
  }

  getAll() {
    return this._http.get(this.PathUrl);
  }

  get(id: number) {
    return this._http.get(this.PathUrl + '/' + id);
  }
}
