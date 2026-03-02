import { Component, inject } from '@angular/core';
import { AsyncPipe, NgIf, NgFor } from '@angular/common';
import { LivrosService } from '../../services/livros.service';
import { Livro } from '../../models/livro.model';

@Component({
  selector: 'app-browse',
  standalone: true,
  imports: [AsyncPipe, NgIf, NgFor],
  templateUrl: './browse.component.html',
  styleUrl: './browse.component.scss'
})
export class BrowseComponent {
  private livrosService = inject(LivrosService);
  livros$ = this.livrosService.getAll();
}
