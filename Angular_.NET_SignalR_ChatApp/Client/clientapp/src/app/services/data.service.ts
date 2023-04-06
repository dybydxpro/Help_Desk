import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:44325/api/';


@Injectable({
  providedIn: 'root'
})

export class DataService {

  constructor(private http: HttpClient) { }

  get(): Observable<any>{
    return this.http.get(`${baseUrl}/Notify`)
  }

  create(data: any): Observable<any>{
    return this.http.post(`${baseUrl}/Notify`, data);
  }
}
