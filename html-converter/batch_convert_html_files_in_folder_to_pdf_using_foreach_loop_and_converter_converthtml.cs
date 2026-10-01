// Batch convert all HTML files in a folder to PDF using a foreach loop and Converter.ConvertHTML.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input_html";
            string outputFolder = "output_pdf";

            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string sampleHtmlPath = System.IO.Path.Combine(inputFolder, "sample.html");
            if (!System.IO.File.Exists(sampleHtmlPath))
            {
                System.IO.File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    string pdfPath = System.IO.Path.ChangeExtension(htmlPath, ".pdf");
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    Console.WriteLine($"Converted: {htmlPath} -> {pdfPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}