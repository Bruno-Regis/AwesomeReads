import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Livro } from '../models/livro.model';
import { ApiResponse } from '../../../shared/interfaces/api-response.interface';
// interface ApiResponse<T> {
//   data: T;
//   isSuccess: boolean;
//   message: string;
// }

@Injectable({
  providedIn: 'root'
})
export class LivrosService {

  private _httpClient = inject(HttpClient);
  apiUrl = 'https://localhost:7149/api';


  getAll(): Observable<Livro[]> {
    return this._httpClient
      .get<ApiResponse<Livro[]>>(`${this.apiUrl}/livros`)
      .pipe(map(res => res.data));
  }

  getById(id: number) {
    return this._httpClient
      .get<ApiResponse<Livro>>(`${this.apiUrl}/livros/${id}`)
      .pipe(map(res => res.data));
  }
}
