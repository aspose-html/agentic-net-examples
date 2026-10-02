// Perform batch conversion of all Markdown files in a folder to PDF using a foreach loop.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputMarkdown";
            string outputFolder = @"C:\OutputPdf";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] markdownFiles = Directory.GetFiles(inputFolder, "*.md", SearchOption.TopDirectoryOnly);

            foreach (string mdPath in markdownFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(mdPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
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