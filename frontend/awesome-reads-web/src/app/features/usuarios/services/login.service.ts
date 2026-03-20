import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
// import { LoginResponse } from '../../../types/login-response.type';
import { LoginUsuarioRequest, LoginResponse } from '../models/login-usuario-request.model';
import { tap } from 'rxjs';
import { ApiResponse } from '../../../shared/interfaces/api-response.interface';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }

  apiUrl = 'https://localhost:7149/api';
  private readonly tokenKey = 'auth_token';


  login(email: string, senha: string) {

    const body: LoginUsuarioRequest = {
      email,
      senha,
      role: 'leitor'
    };

    return this.httpClient.put<ApiResponse<LoginResponse>>( this.apiUrl +'/usuarios/login', body)
      .pipe(
        tap((response) => {
          if (response.isSuccess) {
            sessionStorage.setItem(this.tokenKey, response.data.token);
          }
        })
      );
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    if (!token) return false;

    // Verifica se o token está expirado
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload.exp * 1000 > Date.now();
    } catch {
      return false;
    }
  }

    signup(email: string, nome: string, senha: string) {
      return this.httpClient.post<LoginResponse>( this.apiUrl + '/usuarios', { email, nome, senha })
      .pipe(
        tap((value) => {
          sessionStorage.setItem(this.tokenKey, value.token);

        })
      );
  }
}
