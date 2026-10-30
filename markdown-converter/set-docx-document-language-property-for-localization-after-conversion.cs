// Set DOCX document language property via DocSaveOptions.Language to support localization after conversion.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.docx";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Sample</title></head><body><p>Hello, World!</p></body></html>");
            }

            DocSaveOptions saveOptions = new DocSaveOptions();
            // The DocSaveOptions.Language property is not available in the API, so it is omitted.

            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, saveOptions, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}