using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.DTO
{
    public class AccessInfoDTO
    {
        public string Country { get; set; }

        public string Viewability { get; set; }

        public bool Embeddable { get; set; }

        public bool PublicDomain { get; set; }

        public string TextToSpeechPermission { get; set; }

        public EpubDTO Epub { get; set; }

        public EpubDTO Pdf { get; set; }

        public Uri WebReaderLink { get; set; }

        public string AccessViewStatus { get; set; }

        public bool QuoteSharingAllowed { get; set; }
    }
}
