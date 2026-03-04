import { Component, inject, input, output } from '@angular/core';
import { AvaliacoesService } from '../../services/avaliacoes.service';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CreateAvaliacaoRequest } from '../../models/create-avaliacao-request.model';

@Component({
  selector: 'app-avaliacoes-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './avaliacoes-form.component.html',
  styleUrl: './avaliacoes-form.component.scss'
})
export class AvaliacoesFormComponent {
  private _avaliacoesService = inject(AvaliacoesService);

  livroId = input<number>(0);
  usuarioId = input<number>(0);
  submitted = output<CreateAvaliacaoRequest>();

  reviewForm = new FormGroup({
    nota: new FormControl<number>(0, [Validators.required, Validators.min(1), Validators.max(5)]),
    descricao: new FormControl<string>('', [Validators.required, Validators.minLength(3), Validators.maxLength(500)])
  });

enviar() {
    if (this.reviewForm.invalid) {
      this.reviewForm.markAllAsTouched();
      return;
    }

    this.submitted.emit({
      idLivro: +this.livroId(),
      idUsuario: +this.usuarioId(),
      nota: this.reviewForm.controls.nota.value!,
      descricao: this.reviewForm.controls.descricao.value!.trim()
    });

    this.reviewForm.reset({ nota: 0, descricao: '' });
  }
}
