using AwesomeReads.Application.Models;
using AwesomeReads.Core.Repositories;
using MediatR;

namespace AwesomeReads.Application.Commands.LivrosCommands.InsertLivros
{
    public class InsertLivrosHandler : IRequestHandler<InsertLivrosCommand, ResultViewModel<int>>
    {
        private readonly ILivroRepository _livroRepository;
        public InsertLivrosHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertLivrosCommand request, CancellationToken cancellationToken)
        {
            var livroJaExiste = await _livroRepository.ExistsISBNAsync(request.ISBN);
            if (livroJaExiste) 
                return ResultViewModel<int>.Error("Já existe um livro com este ISBN.");


            string? capaUrl = null;
            string? caminhoCompleto = null;


            if (request.CapaLivro is not null && request.CapaLivro.Length > 0)
            {
                if (request.CapaLivro.Length > 5 * 1024 * 1024)
                    return ResultViewModel<int>.Error("Capa excede 5MB.");

                if (!request.CapaLivro.ContentType.StartsWith("image/"))
                    return ResultViewModel<int>.Error("Arquivo de capa precisa ser uma imagem.");

                // Gera nome único para o arquivo
                var extensao = Path.GetExtension(request.CapaLivro.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                // Salva em wwwroot/images/livros/
                var pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "livros");
                Directory.CreateDirectory(pasta); // cria a pasta se não existir

                caminhoCompleto = Path.Combine(pasta, nomeArquivo);
                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await request.CapaLivro.CopyToAsync(stream);
                }

                // URL relativa que o Angular vai usar
                capaUrl = $"/images/livros/{nomeArquivo}";
            }


            var livro = request.ToEntity();
            livro.AtualizarCapaLivro(capaUrl);
            
            //await _livroRepository.AddAsync(livro);            

            //return ResultViewModel<int>.Success(livro.Id);

            try
            {
                await _livroRepository.AddAsync(livro);
                return ResultViewModel<int>.Success(livro.Id);
            }
            catch
            {
                if (caminhoCompleto is not null && File.Exists(caminhoCompleto))
                    File.Delete(caminhoCompleto);

                return ResultViewModel<int>.Error("Erro ao cadastrar livro.");
            }
        }
    }
}
