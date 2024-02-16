namespace WebApplication.Contract
{
    public class CreateBookCommand
    {
        public required string ISBN { get; set; }
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string Editora { get; set; }
        public required string DataPublicacao { get; set; }
        public required string Genero { get; set; }
        public required string Sinopse { get; set; }
        public required string Idioma { get; set; }
        public required string Paginas { get; set; }
        public required string Avaliacoes { get; set; }
        public required string CodigoBarras { get; set; }
    }
}