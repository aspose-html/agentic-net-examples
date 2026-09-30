// Batch convert mixed HTML and MHTML files to flattened PDFs using a loop with shared PdfSaveOptions.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputFiles";
            string outputDir = "OutputFiles";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string htmlPath = Path.Combine(inputDir, "sample.html");
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello HTML</h1></body></html>");
            }

            string mhtmlPath = Path.Combine(inputDir, "sample.mhtml");
            if (!File.Exists(mhtmlPath))
            {
                File.WriteAllText(mhtmlPath, "<html><body><h1>Hello MHTML</h1></body></html>");
            }

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions
            {
                FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
            };

            string[] files = Directory.GetFiles(inputDir);
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLowerInvariant();
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(file) + ".pdf");

                if (extension == ".html")
                {
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(file);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
                else if (extension == ".mhtml")
                {
                    System.IO.Stream stream = System.IO.File.OpenRead(file);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    stream.Dispose();
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}