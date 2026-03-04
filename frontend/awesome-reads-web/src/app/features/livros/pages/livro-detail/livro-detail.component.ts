import { Component, inject, signal, Signal } from '@angular/core';
import { AvaliacoesFormComponent } from "../../../avaliacoes/components/avaliacoes-form/avaliacoes-form.component";
import { AvaliacoesListComponent } from "../../../avaliacoes/components/avaliacoes-list/avaliacoes-list.component";
import { AvaliacoesService } from '../../../avaliacoes/services/avaliacoes.service';
import { LivrosService } from '../../services/livros.service';
import { ActivatedRoute } from '@angular/router';
import { map, switchMap } from 'rxjs';
import { CreateAvaliacaoRequest } from '../../../avaliacoes/models/create-avaliacao-request.model';
import { NgIf, AsyncPipe } from '@angular/common';
@Component({
  selector: 'app-livro-detail',
  standalone: true,
  imports: [AvaliacoesFormComponent, AvaliacoesListComponent, NgIf, AsyncPipe],
  templateUrl: './livro-detail.component.html',
  styleUrl: './livro-detail.component.scss'
})
export class LivroDetailComponent {
  private route = inject(ActivatedRoute);
  private _avaliacoesService = inject(AvaliacoesService);
  private _livrosService = inject(LivrosService);

  usuarioId = 3; // Substitua pelo ID do usuário logado

  livroId$ = this.route.paramMap.pipe(map(p => Number(p.get('id'))));

 livro$ = this.livroId$.pipe(
    switchMap(id => this._livrosService.getById(id))
  );

  avaliacoes$ = this.livroId$.pipe(
    switchMap(id => this._avaliacoesService.getPorLivroId(id))
  );

  onSubmitAvaliacao(payload: CreateAvaliacaoRequest) {
    // aqui você ainda decide como “refresh” após POST
  }

}
