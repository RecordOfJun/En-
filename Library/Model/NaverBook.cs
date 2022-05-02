using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;
namespace Library.Model
{
    public class SearchResults
    {
        public string lastBulidDate;
        public string total;
        public string start;
        public string display;

        public List<ItemData> items;
    }  
    public class ItemData
    {
        public string title;
        public string author;
        public string price;
        public string publisher;
        public string isbn;
        public string description;
        public string pubdate;
    }
    class NaverBook
    {
        public List<ItemData> GetRequestResult(string bookName,string number)
        {
            string result = "";
            WebRequest request;
            request = WebRequest.Create("https://openapi.naver.com/v1/search/book.json?query="+bookName+"&display="+number);

            request.Headers.Add("X-Naver-Client-Id", "SsfDUUwgAZmuzt8kSFIg");
            request.Headers.Add("X-Naver-Client-Secret", "IzA2jM8MfA");

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            result = reader.ReadToEnd();
            SearchResults searchResults = JsonConvert.DeserializeObject<SearchResults>(result);
            reader.Close();
            dataStream.Close();
            response.Close();

            return searchResults.items;
        }
    }
}
