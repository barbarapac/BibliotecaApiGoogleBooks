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
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Categories { get; set; }
        public string Etag { get; set; }
        public string[] Authors { get; set; }
        public Uri Thumbnail { get; set; }
    }
}
