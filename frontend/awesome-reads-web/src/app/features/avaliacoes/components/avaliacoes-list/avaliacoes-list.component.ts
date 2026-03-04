import { Component, input, output } from '@angular/core';
import { AvaliacaoView } from '../../models/avaliacao-view.model';
import { NgIf, NgFor } from '@angular/common';
@Component({
  selector: 'app-avaliacoes-list',
  standalone: true,
  imports: [NgIf, NgFor],
  templateUrl: './avaliacoes-list.component.html',
  styleUrl: './avaliacoes-list.component.scss'
})
export class AvaliacoesListComponent {
  avaliacoes = input.required<AvaliacaoView[]>();
  deleteClicked = output<number>();

  onDelete(idAvaliacao: number) {
    this.deleteClicked.emit(idAvaliacao);
  }
}
