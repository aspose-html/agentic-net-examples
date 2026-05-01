// Configure user agent string, request a web page, and capture the final rendered HTML source.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            RequestMessage request = new RequestMessage(url);
            request.Timeout = TimeSpan.FromSeconds(30);
            request.Headers["User-Agent"] = "MyCustomAgent/1.0";

            using (HTMLDocument document = new HTMLDocument(request))
            {
                string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}