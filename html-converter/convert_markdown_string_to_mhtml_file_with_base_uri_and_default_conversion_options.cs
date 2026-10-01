// Convert a Markdown string to MHTML file by providing base URI and default conversion options.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample Title\nThis is a **markdown** text.";
            string baseUri = "http://example.com/";
            string outputPath = "output.mhtml";

            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(markdown, baseUri, options, outputPath);

            System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}