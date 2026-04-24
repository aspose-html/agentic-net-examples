// Develop a console application that accepts command‑line arguments for source HTML path and target format.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
                throw new ArgumentException("Usage: <sourceHtmlPath> <targetFormat>");

            string sourcePath = args[0];
            string targetFormat = args[1].ToLowerInvariant();

            if (!File.Exists(sourcePath))
                throw new FileNotFoundException("Source HTML file not found.", sourcePath);

            string outputPath = Path.ChangeExtension(sourcePath,
                targetFormat == "mhtml" ? ".mhtml" :
                targetFormat == "pdf" ? ".pdf" :
                targetFormat == "docx" ? ".docx" :
                throw new NotSupportedException($"Target format '{targetFormat}' is not supported."));

            switch (targetFormat)
            {
                case "mhtml":
                    // Rule: convert-html-to-mhtml_2
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
                    Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, mhtmlOptions, outputPath);
                    break;

                case "pdf":
                    Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, pdfOptions, outputPath);
                    break;

                case "docx":
                    Aspose.Html.Saving.DocSaveOptions docOptions = new Aspose.Html.Saving.DocSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, docOptions, outputPath);
                    break;
            }

            Console.WriteLine($"Conversion succeeded. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}