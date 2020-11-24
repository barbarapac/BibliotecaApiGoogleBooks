using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.DTO
{
    public class EpubDTO
    {
        public bool isAvailable { get; set; }

        public Uri acsTokenLink { get; set; }
    }
}
