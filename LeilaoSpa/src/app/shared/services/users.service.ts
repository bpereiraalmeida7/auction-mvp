import { environment } from '../../../environments/environment';
import { User } from '../models/user';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<User[]>(`${environment.api}/api/Usuarios`);
  }

  getById(id: string) {
    return this.http.get<User>(`${environment.api}/api/Usuarios/${id}`);
  }
}
