using WebApplication.Contract;
using WebApplication.Entity;

namespace WebApplication.Service
{
    public class BookMapper
    {
        public Book Convert(CreateBookCommand command)
        {
            return new Book()
            {
                ISBN = command.ISBN,
                Titulo = command.Titulo,
                Autor = command.Autor,
                Editora = command.Editora,
                DataPublicacao = command.DataPublicacao,
                Genero = command.Genero,
                Sinopse = command.Sinopse,
                Idioma = command.Idioma,
                Paginas = command.Paginas,
                Avaliacoes = command.Avaliacoes,
                CodigoBarras = command.CodigoBarras
            };
        }
    }
}
