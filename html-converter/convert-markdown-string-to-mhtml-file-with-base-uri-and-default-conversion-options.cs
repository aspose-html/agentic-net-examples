// Convert a Markdown string to MHTML file by providing base URI and default conversion options.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample Title\n\nThis is a **markdown** text.";
            string baseUri = "about:blank";
            string outputPath = "output.mhtml";

            MHTMLSaveOptions options = new MHTMLSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(markdown, baseUri, options, outputPath);

            System.Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}