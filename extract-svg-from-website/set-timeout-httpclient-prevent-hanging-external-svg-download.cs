// Set a timeout on HttpClient to prevent hanging during external SVG download.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com/sample.svg";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(10);
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request))
            {
                string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine("Loaded SVG document outer HTML length: " + html.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}