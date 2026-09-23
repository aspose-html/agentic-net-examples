// Implement error handling to skip extraction when the HTML page cannot be loaded.

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
            HTMLElement body = document.Body;
            string content = body.TextContent;
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("timed out"))
            {
                Console.WriteLine("Skipping extraction due to load failure.");
            }
            else
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}