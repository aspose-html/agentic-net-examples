// Set a custom timeout value when loading HTML from remote URLs to avoid long waits.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(10);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request);
            string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
            System.Console.WriteLine(html);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}