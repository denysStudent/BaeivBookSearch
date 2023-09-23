using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.WebPages;
using BookSearch;
using System.Web.Mvc;
using BookSearch.Controllers;

// Model, used to map JSON responce
namespace BookSearch.Models
{
    // Class which represents response from the Google Book API call
    // It was retrieved with the help of Json to C# converter after getting response example
    public class BookModel
    {
        // Method which is used for sending an API call
        // Response is in the form of the JSON
        public Object getBookList(string title, string author)
        {
            string url = string.Format("https://www.googleapis.com/books/v1/volumes?q=intitle:{0}+inauthor:{1}&format=json&nojsoncallback=1", title, author);

            var client = new WebClient();

            try
            {
                var content = client.DownloadString(url);
                var jsonContent = new JavaScriptSerializer().Deserialize<Root>(content);
                return jsonContent;
            }
            catch
            {
                return ("Wrong search. Check your query parameters.");
            }
        }

        // Model for recieved JSON object
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class AccessInfo
        {
            public string country { get; set; }
            public string viewability { get; set; }
            public bool embeddable { get; set; }
            public bool publicDomain { get; set; }
            public string textToSpeechPermission { get; set; }
            public Epub epub { get; set; }
            public Pdf pdf { get; set; }
            public string webReaderLink { get; set; }
            public string accessViewStatus { get; set; }
            public bool quoteSharingAllowed { get; set; }
        }

        public class Epub
        {
            public bool isAvailable { get; set; }
            public string acsTokenLink { get; set; }
        }

        public class ImageLinks
        {
            public string smallThumbnail { get; set; }
            public string thumbnail { get; set; }
        }

        public class IndustryIdentifier
        {
            public string type { get; set; }
            public string identifier { get; set; }
        }

        public class Item
        {
            public string kind { get; set; }
            public string id { get; set; }
            public string etag { get; set; }
            public string selfLink { get; set; }
            public VolumeInfo volumeInfo { get; set; }
            public SaleInfo saleInfo { get; set; }
            public AccessInfo accessInfo { get; set; }
            public SearchInfo searchInfo { get; set; }
        }

        public class ListPrice
        {
            public double amount { get; set; }
            public string currencyCode { get; set; }
            public int amountInMicros { get; set; }
        }

        public class Offer
        {
            public int finskyOfferType { get; set; }
            public ListPrice listPrice { get; set; }
            public RetailPrice retailPrice { get; set; }
            public bool giftable { get; set; }
        }

        public class PanelizationSummary
        {
            public bool containsEpubBubbles { get; set; }
            public bool containsImageBubbles { get; set; }
        }

        public class Pdf
        {
            public bool isAvailable { get; set; }
            public string acsTokenLink { get; set; }
        }

        public class ReadingModes
        {
            public bool text { get; set; }
            public bool image { get; set; }
        }

        public class RetailPrice
        {
            public double amount { get; set; }
            public string currencyCode { get; set; }
            public int amountInMicros { get; set; }
        }

        public class Root
        {
            public string kind { get; set; }
            public int totalItems { get; set; }
            public List<Item> items { get; set; }
        }

        public class SaleInfo
        {
            public string country { get; set; }
            public string saleability { get; set; }
            public bool isEbook { get; set; }
            public ListPrice listPrice { get; set; }
            public RetailPrice retailPrice { get; set; }
            public string buyLink { get; set; }
            public List<Offer> offers { get; set; }
        }

        public class SearchInfo
        {
            public string textSnippet { get; set; }
        }

        public class VolumeInfo
        {
            public string title { get; set; }
            public List<string> authors { get; set; }
            public string publisher { get; set; }
            public string publishedDate { get; set; }
            public string description { get; set; }
            public List<IndustryIdentifier> industryIdentifiers { get; set; }
            public ReadingModes readingModes { get; set; }
            public int pageCount { get; set; }
            public string printType { get; set; }
            public List<string> categories { get; set; }
            public double averageRating { get; set; }
            public int ratingsCount { get; set; }
            public string maturityRating { get; set; }
            public bool allowAnonLogging { get; set; }
            public string contentVersion { get; set; }
            public PanelizationSummary panelizationSummary { get; set; }
            public ImageLinks imageLinks { get; set; }
            public string language { get; set; }
            public string previewLink { get; set; }
            public string infoLink { get; set; }
            public string canonicalVolumeLink { get; set; }
            public string subtitle { get; set; }
        }


    }
}