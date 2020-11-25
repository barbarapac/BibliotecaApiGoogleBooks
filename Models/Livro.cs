using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.Models
{
    public class Livro
    {
        public Livro() {}

        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categorias { get; set; }
        public string Etag { get; set; }
        public string Autores { get; set; }
        public Uri CapaLivro { get; set; }
    }
}
