// After each conversion, verify that the output PDF or HTML file exists and is not empty before proceeding.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            if (!File.Exists(outputPath))
            {
                throw new Exception("PDF file was not created.");
            }

            if (new FileInfo(outputPath).Length == 0)
            {
                throw new Exception("PDF file is empty.");
            }

            Console.WriteLine("Conversion succeeded and PDF file verified.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}