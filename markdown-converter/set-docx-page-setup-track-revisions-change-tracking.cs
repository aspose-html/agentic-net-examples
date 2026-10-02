// Set DOCX page setup to track revisions using DocSaveOptions.TrackRevisions for change tracking.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var options = new Aspose.Html.Saving.DocSaveOptions();
            // Note: DocSaveOptions does not expose a TrackRevisions property in the current API.

            string outputPath = "output.docx";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion to DOCX completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}