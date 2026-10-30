// Batch convert a folder of HTML files to PDF, applying the same conversion options to each.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputPdf";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");

                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during batch conversion: " + ex.Message);
        }
    }
}