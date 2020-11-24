using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.DTO
{
    public class OfferDTO
    {
        public long finskyOfferType { get; set; }
        public OfferListPriceDTO listPrice { get; set; }
        public OfferListPriceDTO retailPrice { get; set; }
        public bool Giftable { get; set; }
    }
}
