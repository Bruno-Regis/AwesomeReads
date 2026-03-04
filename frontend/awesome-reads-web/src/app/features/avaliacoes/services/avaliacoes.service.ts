import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { CreateAvaliacaoRequest } from '../models/create-avaliacao-request.model';
import { AvaliacaoView } from '../models/avaliacao-view.model';
import { ApiResponse } from '../../../shared/interfaces/api-response.interface';

@Injectable({
  providedIn: 'root'
})
export class AvaliacoesService {

  private _httpClient = inject(HttpClient);
  apiUrl = `https://localhost:7149/api/avaliacoes`;

  insertAvaliacao(avaliacao: CreateAvaliacaoRequest){
    return this._httpClient.post<CreateAvaliacaoRequest>(`${this.apiUrl}`, avaliacao);
  }

  getPorLivroId(idLivro: number) {
    return this._httpClient
      .get<ApiResponse<AvaliacaoView[]>>(`${this.apiUrl}/livro/${idLivro}`)
      .pipe(map(res => res.data));
  }

  deleteAvaliacao(idAvaliacao: number) {
    return this._httpClient.delete(`${this.apiUrl}/${idAvaliacao}`);
  }

}
