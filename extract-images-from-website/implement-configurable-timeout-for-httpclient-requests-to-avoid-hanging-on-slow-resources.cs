// Implement a configurable timeout for HttpClient requests to avoid hanging on slow resources.

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
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request))
            {
                string html = document.DocumentElement != null
                    ? ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML
                    : string.Empty;
                System.Console.WriteLine(html);
            }
        }
        catch (System.TimeoutException)
        {
            System.Console.WriteLine("The request timed out.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}