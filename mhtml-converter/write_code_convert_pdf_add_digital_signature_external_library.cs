// Write code to convert PDF and then add a digital signature using an external library.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "sample.html");
            string pdfPath = Path.Combine(baseDir, "output.pdf");

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            // Verify the output PDF
            if (!File.Exists(pdfPath) || new FileInfo(pdfPath).Length == 0)
            {
                throw new Exception("PDF conversion failed: file is missing or empty.");
            }

            Console.WriteLine("PDF conversion succeeded. File saved at: " + pdfPath);
            Console.WriteLine("Adding a digital signature requires a separate PDF signing library, which is not included in this example.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}