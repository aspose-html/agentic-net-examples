// Batch convert a folder of HTML files to PDF, applying the same conversion options to each.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html", SearchOption.TopDirectoryOnly);
            foreach (string htmlPath in htmlFiles)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    options.BackgroundColor = System.Drawing.Color.White;

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
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