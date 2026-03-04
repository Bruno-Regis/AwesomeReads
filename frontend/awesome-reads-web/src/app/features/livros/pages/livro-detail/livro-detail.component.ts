import { Component, inject, signal, Signal } from '@angular/core';
import { AvaliacoesFormComponent } from "../../../avaliacoes/components/avaliacoes-form/avaliacoes-form.component";
import { AvaliacoesListComponent } from "../../../avaliacoes/components/avaliacoes-list/avaliacoes-list.component";
import { AvaliacoesService } from '../../../avaliacoes/services/avaliacoes.service';
import { LivrosService } from '../../services/livros.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { combineLatest, map, switchMap } from 'rxjs';
import { CreateAvaliacaoRequest } from '../../../avaliacoes/models/create-avaliacao-request.model';
import { NgIf, AsyncPipe } from '@angular/common';
import { toObservable } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-livro-detail',
  standalone: true,
  imports: [AvaliacoesFormComponent, AvaliacoesListComponent, NgIf, AsyncPipe, RouterLink],
  templateUrl: './livro-detail.component.html',
  styleUrl: './livro-detail.component.scss'
})
export class LivroDetailComponent {
  private route = inject(ActivatedRoute);
  private _avaliacoesService = inject(AvaliacoesService);
  private _livrosService = inject(LivrosService);

  private refreshToken = signal<number>(0);

  usuarioId = 3; // Substitua pelo ID do usuário logado

  livroId$ = this.route.paramMap.pipe(map(p => Number(p.get('id'))));

  livro$ = this.livroId$.pipe(
      switchMap(id => this._livrosService.getById(id))
    );

  avaliacoes$ = combineLatest([this.livroId$, toObservable(this.refreshToken)]).pipe(
    switchMap(([id]) => this._avaliacoesService.getPorLivroId(id))
  );

  private triggerRefreshAvaliacoes() {
    this.refreshToken.update(v => v + 1);
  }

  onSubmitAvaliacao(payload: CreateAvaliacaoRequest) {
      this._avaliacoesService.insertAvaliacao({
      idLivro: payload.idLivro,
      idUsuario: payload.idUsuario,
      nota: payload.nota,
      descricao: payload.descricao,
    })
    .subscribe({
      next: () => this.triggerRefreshAvaliacoes(),
      error: (e) => console.error('Erro ao enviar avaliação', e),
    });
  }

    onDeleteAvaliacao(idAvaliacao: number) {
    this._avaliacoesService.deleteAvaliacao(idAvaliacao)
      .subscribe({
        next: () => this.triggerRefreshAvaliacoes(),
        error: (e) => console.error('Erro ao excluir avaliação', e),
      });
  }
}
