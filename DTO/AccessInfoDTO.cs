using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.DTO
{
    public class AccessInfoDTO
    {
        public string country { get; set; }
        public string viewability { get; set; }
        public bool embeddable { get; set; }
        public bool publicDomain { get; set; }
        public string textToSpeechPermission { get; set; }
        public EpubDTO epub { get; set; }
        public EpubDTO pdf { get; set; }
        public Uri webReaderLink { get; set; }
        public string accessViewStatus { get; set; }
        public bool quoteSharingAllowed { get; set; }
    }
}
