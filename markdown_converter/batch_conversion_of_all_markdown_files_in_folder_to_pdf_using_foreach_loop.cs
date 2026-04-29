// Perform batch conversion of all Markdown files in a folder to PDF using a foreach loop.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

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

                HTMLDocument document = Converter.ConvertMarkdown(mdPath);
                Converter.ConvertHTML(document, new PdfSaveOptions(), pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}