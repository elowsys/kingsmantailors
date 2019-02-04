import { Injectable } from '@angular/core';
import { THROW_IF_NOT_FOUND } from '@angular/core/src/di/injector';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

// manually add headers
// const httpOptions = {
//   headers: new HttpHeaders({
//     Authorization: 'Bearer ' + localStorage.getItem('token')
//   })
// };

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private _baseUrl = environment.apiUrl;
  constructor(public http: HttpClient, private _pathPrefix: string) {}

  get BaseUrl() {
    return this._baseUrl + this._pathPrefix;
  }

  getAll<T>() {
    // return this.http.get<T>(this.BaseUrl, httpOptions);
    return this.http.get<T>(this.BaseUrl);
  }

  get<T>(id: number) {
    return this.http.get<T>(this.BaseUrl + '/' + id);
  }

  getSpecial<T>(id: string) {
    return this.http.get<T>(this.BaseUrl + id);
  }

  create<T>(model: any) {
    return this.http.post<T>(this.BaseUrl, model);
  }
}
