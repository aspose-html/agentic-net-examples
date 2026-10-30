// Create an HTML document from a raw string, set document title, and save as MHTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Placeholder</title></head><body><h1>Hello World</h1></body></html>";
            string outputPath = "output.mhtml";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                document.Title = "Sample Document";
                document.Save(outputPath, Aspose.Html.Saving.HTMLSaveFormat.MHTML);
            }

            System.Console.WriteLine("MHTML file saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}