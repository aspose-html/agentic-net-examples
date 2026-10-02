// Load an HTML document from a URL using custom network timeout, and handle timeout exceptions gracefully.

using System;

public class Program
{
    public static void Main()
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
        catch (System.Exception ex)
        {
            if (ex.Message.Contains("timed out"))
            {
                System.Console.WriteLine("Network timeout occurred while loading the HTML document.");
            }
            else
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}