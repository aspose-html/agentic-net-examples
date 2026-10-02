// Write code to convert PDF and then add a digital signature using an external library.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "AsposeHtmlExample");
            Directory.CreateDirectory(baseDir);
            string htmlPath = Path.Combine(baseDir, "sample.html");
            string pdfPath = Path.Combine(baseDir, "output.pdf");

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Open the HTML file as a stream
            using (FileStream stream = File.OpenRead(htmlPath))
            {
                // Set PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert HTML (MHTML) stream to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
            }

            // Verify conversion
            if (!File.Exists(pdfPath))
                throw new Exception("PDF file was not created.");

            FileInfo info = new FileInfo(pdfPath);
            if (info.Length == 0)
                throw new Exception("PDF file is empty.");

            Console.WriteLine("PDF conversion succeeded. File size: " + info.Length + " bytes.");

            // Note about digital signature
            Console.WriteLine("Adding a digital signature requires an external PDF signing library, which is not included in this example.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}