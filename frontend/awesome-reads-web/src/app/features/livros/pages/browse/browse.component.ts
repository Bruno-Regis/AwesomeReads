import { Component, inject } from '@angular/core';
import { AsyncPipe, NgIf, NgFor } from '@angular/common';
import { LivrosService } from '../../services/livros.service';
import { AvaliacoesFormComponent } from "../../../avaliacoes/components/avaliacoes-form/avaliacoes-form.component";
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-browse',
  standalone: true,
  imports: [AsyncPipe, NgIf, NgFor, AvaliacoesFormComponent, RouterLink],
  templateUrl: './browse.component.html',
  styleUrl: './browse.component.scss'
})
export class BrowseComponent {
  private livrosService = inject(LivrosService);

  livros$ = this.livrosService.getAll();

}
