// Load HTML content from a URL stream while specifying a custom user‑agent header for the request.

using System;
using System.Net;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "MyCustomUserAgent/1.0";

            using (WebResponse response = request.GetResponse())
            using (System.IO.Stream stream = response.GetResponseStream())
            {
                var document = new Aspose.Html.HTMLDocument(stream, url);
                Console.WriteLine("HTML loaded successfully. Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}