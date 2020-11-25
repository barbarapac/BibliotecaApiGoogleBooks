using BibliotecaApiGoogleBooks.DataBase;
using BibliotecaApiGoogleBooks.Models;
using BibliotecaApiGoogleBooks.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.Repositories
{
    public class LivroRepository : ILivroRepository
    {

        private readonly BibliotecaApiGoogleBooksContext _context;

        public LivroRepository(BibliotecaApiGoogleBooksContext context)
        {
            _context = context;
        }

        public IEnumerable<Livro> Livros => _context.Livros.ToList();

        public void ExcluirLivro(Livro livro)
        {
            try
            {
                _context.Livros.Remove(livro);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao tentar remover o livro. Tente novamente.");
            }
        }

        public Livro GetByID(string ID)
        {
            try
            {
                return _context.Livros.FirstOrDefault(e => e.Id == ID);
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao listar seus livros favoritos. Tente novamente.");
            }
        }

        public void SalvarLivroFavorito(Livro livro)
        {
            try
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao tentar adicionar o livro a sua lista de favoritos. Tente novamente.");
            }
        }
    }
}
