using BibliotecaApiGoogleBooks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.DataBase
{
    public class BibliotecaApiGoogleBooksContext : DbContext
    {

        public BibliotecaApiGoogleBooksContext(DbContextOptions<BibliotecaApiGoogleBooksContext> options) : base(options)
        {

        }

        public DbSet<Livro> Livros { get; set; }

    }
}
