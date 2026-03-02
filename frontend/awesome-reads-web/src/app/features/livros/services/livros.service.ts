import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Livro } from '../models/livro.model';

interface ApiResponse<T> {
  data: T;
  isSuccess: boolean;
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class LivrosService {

  private http = inject(HttpClient);
  apiUrl = 'https://localhost:7149/api';

  getAll(): Observable<Livro[]> {
    return this.http
      .get<ApiResponse<Livro[]>>(`${this.apiUrl}/livros`)
      .pipe(map(res => res.data));
  }
}
