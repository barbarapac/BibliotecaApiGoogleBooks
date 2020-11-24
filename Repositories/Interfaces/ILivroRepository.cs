using BibliotecaApiGoogleBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> Livros { get; }
        Livro GetByID(int ID);
        void SalvarLivroFavorito(Livro livro);
        void ExcluirLivro(Livro livro);
    }
}
