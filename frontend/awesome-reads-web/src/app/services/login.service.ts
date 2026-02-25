import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from '../types/login-response.type';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  apiUrl = 'https://localhost:7149/api';
  constructor(private httpClient: HttpClient) { }

  login(email: string, password: string) {
      return this.httpClient.post<LoginResponse>('/api/login', { email, password }).pipe(
        tap((value) => {
          sessionStorage.setItem('auth-token', value.token);
          sessionStorage.setItem('user-name', value.user);
        })
      );
  }


    signup(email: string, nome: string, senha: string) {
      return this.httpClient.post<LoginResponse>( this.apiUrl + '/usuarios', { email, nome, senha }).pipe(
        tap((value) => {
          //sessionStorage.setItem('auth-token', value.token);
          sessionStorage.setItem('user-name', value.user);
        })
      );

  }
}
