// Load HTML content from a URL stream while specifying a custom user‑agent header for the request.

using System;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MyCustomUserAgent/1.0");
            string html = httpClient.GetStringAsync(url).Result;

            var document = new Aspose.Html.HTMLDocument(html, url);

            HTMLCollection titleCollection = document.GetElementsByTagName("title");
            string titleText = "";
            if (titleCollection.Length > 0)
            {
                var titleElement = titleCollection[0] as Aspose.Html.HTMLElement;
                if (titleElement != null)
                {
                    titleText = titleElement.InnerHTML;
                }
            }

            Console.WriteLine("Page title: " + titleText);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}