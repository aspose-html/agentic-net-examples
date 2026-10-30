// Load an HTML document from a URL using custom network timeout, and handle timeout exceptions gracefully.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(10);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request);
            string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
            Console.WriteLine(html);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("timeout"))
            {
                Console.WriteLine("Network timeout occurred.");
            }
            else
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}