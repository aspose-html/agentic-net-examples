// Create an HTML document from a raw string, set document title, and save as MHTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Original</title></head><body><h1>Hello World</h1></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            document.Title = "My Document Title";

            string outputPath = "output.mhtml";
            document.Save(outputPath, Aspose.Html.Saving.HTMLSaveFormat.MHTML);

            Console.WriteLine("MHTML file saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}