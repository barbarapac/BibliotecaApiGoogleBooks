using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.DTO
{
    public class ItemDTO
    {
        public string kind { get; set; }

        public string id { get; set; }

        public string etag { get; set; }

        public Uri selfLink { get; set; }

        public VolumeInfoDTO volumeInfo { get; set; }

        public SaleInfoDTO saleInfo { get; set; }

        public AccessInfoDTO accessInfo { get; set; }

        public SaleInfoDTO searchInfo { get; set; }
    }
}
