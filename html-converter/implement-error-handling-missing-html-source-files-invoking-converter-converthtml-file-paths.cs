// Implement error handling for missing HTML source files when invoking Converter.ConvertHTML with file paths.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.mhtml";

            if (!System.IO.File.Exists(sourcePath))
            {
                throw new System.IO.FileNotFoundException($"Source HTML file not found: {sourcePath}");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}