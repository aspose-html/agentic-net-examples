// Batch convert a folder of HTML files to PDF using Converter.ConvertHTML inside a foreach loop.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "HtmlFiles");
            string outputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "PdfOutput");
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Ensure at least one sample HTML file exists
            string[] existingFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                System.IO.File.WriteAllText(samplePath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string pdfFileName = System.IO.Path.ChangeExtension(System.IO.Path.GetFileName(htmlPath), ".pdf");
                    string pdfPath = System.IO.Path.Combine(outputFolder, pdfFileName);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                }
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}