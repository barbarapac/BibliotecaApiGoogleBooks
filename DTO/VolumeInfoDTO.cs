using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiGoogleBooks.DTO
{
    public class VolumeInfoDTO
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public string publisher { get; set; }
        public DateTimeOffset publishedDate { get; set; }
        public string description { get; set; }
        public IndustryIdentifierDTO[] industryIdentifiers { get; set; }
        public ReadingModesDTO readingModes { get; set; }
        public long pageCount { get; set; }
        public string printType { get; set; }
        public string[] categories { get; set; }
        public string maturityRating { get; set; }
        public bool allowAnonLogging { get; set; }
        public string contentVersion { get; set; }
        public PanelizationSummaryDTO panelizationSummary { get; set; }
        public ImageLinksDTO imageLinks { get; set; }
        public string language { get; set; }
        public Uri previewLink { get; set; }
        public Uri infoLink { get; set; }
        public Uri canonicalVolumeLink { get; set; }
    }
}
