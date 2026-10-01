// Implement error handling for missing HTML source files when invoking Converter.ConvertHTML with file paths.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "missing.html";
            string outputPath = "output.mhtml";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath))
            {
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion succeeded.");
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine($"Source file not found: {ex.FileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}