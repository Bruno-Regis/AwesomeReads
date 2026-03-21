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
            localStorage.setItem(this.tokenKey, response.data.token);
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

  getUsuarioLogado(): { id: number; email: string; role: string } | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return {
        id: Number(payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier']),
        email: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'],
        role: payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
      };
    } catch {
      return null;
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
