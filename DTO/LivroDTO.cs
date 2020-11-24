using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.DTO
{
    public class LivroDTO
    {

        public string kind { get; set; }

        public long totalItems { get; set; }
        public ItemDTO[] items { get; set; }
    }
}
