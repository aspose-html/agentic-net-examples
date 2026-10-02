// Implement error handling to skip extraction when the HTML page cannot be loaded.

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com/nonexistent.html";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(10);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request))
            {
                Aspose.Html.HTMLElement body = document.Body;
                string content = body.TextContent;
                Console.WriteLine("Page content:");
                Console.WriteLine(content);
            }
        }
        catch (System.Exception ex)
        {
            if (ex.Message.Contains("cannot be loaded"))
            {
                Console.WriteLine("Skipping extraction: page could not be loaded.");
            }
            else
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}