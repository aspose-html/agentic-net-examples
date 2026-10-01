// Read HTML content from standard input or file, convert it to MHTML using Converter.ConvertHTML, and save the output as an .mhtml file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.mhtml";

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}