import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from '../../../types/login-response.type';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  apiUrl = 'https://localhost:7149/api';
  constructor(private httpClient: HttpClient) { }

  login(email: string, senha: string) {
      return this.httpClient.post<LoginResponse>( this.apiUrl +'/usuarios/login', { email, senha })
      .pipe(
        tap((value) => {
          console.log('login response:', value);
          sessionStorage.setItem('auth-token', value.token);
          sessionStorage.setItem('nome', value.user);
        })
      );
  }

    signup(email: string, nome: string, senha: string) {
      return this.httpClient.post<LoginResponse>( this.apiUrl + '/usuarios', { email, nome, senha })
      .pipe(
        tap((value) => {

          sessionStorage.setItem('auth-token', value.token);
          sessionStorage.setItem('user-name', value.user);
        })
      );

  }
}
