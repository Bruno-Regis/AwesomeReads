import { Component, input } from '@angular/core';
import { AvaliacaoView } from '../../models/avaliacao-view.model';
import { NgIf, NgFor, AsyncPipe } from '@angular/common';
@Component({
  selector: 'app-avaliacoes-list',
  standalone: true,
  imports: [NgIf, NgFor, AsyncPipe],
  templateUrl: './avaliacoes-list.component.html',
  styleUrl: './avaliacoes-list.component.scss'
})
export class AvaliacoesListComponent {
  avaliacoes = input.required<AvaliacaoView[]>();
}
