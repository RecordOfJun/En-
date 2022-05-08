using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using Library.View;
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
        ExceptionView exceptionView;
        public NaverBook(ExceptionView exceptionView)
        {
            this.exceptionView = exceptionView;
        }
        public List<ItemData> GetRequestResult(string bookName,string number)//naver openAPI이용 도서정보 불러오기
        {
            string result = "";
            WebRequest request;
            request = WebRequest.Create(Constant.BOOK_SEARCH_URL+bookName + "&display="+101);//검색어와 수량으로 도서리스트 불러오기

            request.Headers.Add("X-Naver-Client-Id", Constant.CLIENT_ID);//클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", Constant.CLIENT_SECRET);//클라이언트 PW
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
                SearchResults searchResults = JsonConvert.DeserializeObject<SearchResults>(result);//받아온 정보 JSON으로 분류
                reader.Close();
                dataStream.Close();
                response.Close();
                foreach (ItemData item in searchResults.items)
                {
                    item.title = RemoveString(item.title);
                    item.author = RemoveString(item.author);
                    item.price = RemoveString(item.price);
                    item.publisher = RemoveString(item.publisher);
                    item.pubdate = RemoveString(item.pubdate);
                    item.description = RemoveString(item.description);
                    if (item.description.Length > 100)
                        item.description = item.description.Remove(100) + "...";
                    item.isbn = RemoveString(item.isbn);
                }
                return searchResults.items;
            }
            catch (Exception e)
            {
                Console.SetCursorPosition(0, Console.CursorTop + 2);
                exceptionView.InsertException(0, e.Message);
                return null;
            }
        }

        private string RemoveString(string data)
        {
            return data.Replace("</b>", "").Replace("<b>", "");
        }
    }
}
