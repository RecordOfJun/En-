using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
namespace Library.Model
{
    class NaverBook
    {

        public string GetRequestResult(string bookName,string number)
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
            reader.Close();
            dataStream.Close();
            response.Close();
            return result;
        }
    }
}
