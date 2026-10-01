// Run the Converter class in a console utility to convert HTML files supplied via command‑line arguments.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = args.Length > 0 ? args[0] : "sample.html";
            string outputPath = args.Length > 1 ? args[1] : "output.jpg";

            if (!File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(sourcePath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine($"Conversion completed successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}