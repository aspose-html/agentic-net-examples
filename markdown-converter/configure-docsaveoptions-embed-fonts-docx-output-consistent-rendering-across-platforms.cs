// Configure DocSaveOptions to embed fonts in the DOCX output for consistent rendering across platforms.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello, World!</p></body></html>");
            }

            string outputPath = "output.docx";

            DocSaveOptions options = new DocSaveOptions();
            options.FontEmbeddingRule = FontEmbeddingRule.Full;

            Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}