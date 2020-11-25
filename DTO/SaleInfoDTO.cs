using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.DTO
{
    public class SaleInfoDTO
    {
        public string country { get; set; }
        public string saleability { get; set; }
        public bool isEbook { get; set; }
        public SaleInfoListPriceDTO listPrice { get; set; }
        public SaleInfoListPriceDTO retailPrice { get; set; }
        public Uri buyLink { get; set; }
        public OfferDTO[] offers { get; set; }
    }
}
