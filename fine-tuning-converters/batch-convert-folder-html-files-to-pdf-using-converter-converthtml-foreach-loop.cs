// Batch convert a folder of HTML files to PDF using Converter.ConvertHTML inside a foreach loop.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";

            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string pdfPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    System.Console.WriteLine($"Converted: {htmlPath} -> {pdfPath}");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}