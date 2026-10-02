// Configure a timeout for the RequestMessage to avoid hanging.

using System;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");
            request.Timeout = System.TimeSpan.FromSeconds(10);
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
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