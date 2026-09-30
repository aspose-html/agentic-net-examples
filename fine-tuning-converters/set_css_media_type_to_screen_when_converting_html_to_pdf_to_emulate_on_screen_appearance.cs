// Set CSS media type to Screen when converting HTML to PDF to emulate on‑screen appearance.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><style>body {font-family:Arial;}</style></head><body><h1>Hello, World!</h1><p>This is a sample HTML for PDF conversion.</p></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}