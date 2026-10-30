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

            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if the input folder is empty
            if (System.IO.Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                System.IO.File.WriteAllText(samplePath, "<html><body><h1>Hello World</h1></body></html>");
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string pdfPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    System.Console.WriteLine($"Converted '{htmlPath}' to '{pdfPath}'.");
                }
            }

            System.Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}