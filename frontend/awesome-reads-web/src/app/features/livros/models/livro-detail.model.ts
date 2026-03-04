import { AvaliacaoView } from "../../avaliacoes/models/avaliacao-view.model";

export interface LivroDetail {
  id: number;
  titulo: string;
  descricao: string;
  isbn: string;
  autor: string;
  editora: string;
  genero: number;
  anoDePublicacao: number;
  quantidadeDePaginas: number;

  notaMedia: number;
  quantidadeDeAvaliacoes: number;

  avaliacoes?: AvaliacaoView[];
}
