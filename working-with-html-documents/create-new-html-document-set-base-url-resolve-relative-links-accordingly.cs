// Create a new HTML document, set its base URL, and resolve relative links accordingly.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head></head><body><a href=\"page2.html\">Link</a></body></html>";
            string baseUrl = "http://example.com/folder/";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html, baseUrl);
            string outputPath = "output.html";
            doc.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}