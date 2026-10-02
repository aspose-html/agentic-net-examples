// Set a custom timeout value when loading HTML from remote URLs to avoid long waits.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            RequestMessage request = new RequestMessage(url);
            request.Timeout = TimeSpan.FromSeconds(10);
            HTMLDocument document = new HTMLDocument(request);
            string html = ((HTMLElement)document.DocumentElement).OuterHTML;
            Console.WriteLine(html);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}