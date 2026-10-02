// Convert a Markdown string to MHTML file by providing base URI and default conversion options.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string markdownContent = "# Sample Title\n\nThis is a **markdown** text.";
            string baseUri = "file:///C:/temp/";
            string outputPath = "output.mhtml";

            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(markdownContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion completed. MHTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}