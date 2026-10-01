// Load HTML content from a URL stream while specifying a custom user‑agent header for the request.

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("MyCustomAgent/1.0");
                using (Stream stream = client.GetStreamAsync(url).Result)
                {
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(stream, url);
                    Console.WriteLine("HTML document loaded successfully.");
                    Console.WriteLine("Title: " + document.Title);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}