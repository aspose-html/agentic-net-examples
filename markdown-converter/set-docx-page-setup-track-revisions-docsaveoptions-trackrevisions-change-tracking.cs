// Set DOCX page setup to track revisions using DocSaveOptions.TrackRevisions for change tracking.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            var options = new Aspose.Html.Saving.DocSaveOptions();
            // The DocSaveOptions class does not expose a TrackRevisions property in the current API.
            string outputPath = "output.docx";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            System.Console.WriteLine("DOCX conversion completed: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}