import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

const baseUrl = 'https://localhost:44320/api/';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient) { }

  getAllUser(): Observable<any>{
    return this.http.get(`${baseUrl}/User`)
  }

  getOneByIdUser(id: number): Observable<any>{
    return this.http.get(`${baseUrl}/User/${id}`);
  }

  createUser(data: any): Observable<any>{
    return this.http.post(`${baseUrl}/User`, data);
  }

  updateUser(data: any): Observable<any>{
    return this.http.post(`${baseUrl}/User`, data);
  }

  deleteUser(id: number): Observable<any>{
    return this.http.delete(`${baseUrl}/User/${id}`);
  }
}
