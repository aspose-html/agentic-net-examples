// Convert an EPUB file to PDF and apply custom CSS styles using PdfSaveOptions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the input EPUB, custom CSS, and output PDF files
            string epubPath = "input.epub";
            string cssPath = "custom.css";
            string outputPdfPath = "output.pdf";

            // Open the EPUB file as a readable stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Read the custom CSS content
                string cssContent = File.ReadAllText(cssPath);

                // Create a configuration and set the user stylesheet to the custom CSS
                Configuration config = new Configuration();
                IUserAgentService userAgent = (IUserAgentService)config.GetService(typeof(IUserAgentService));
                userAgent.UserStyleSheet = cssContent;

                // Initialize PDF save options (default settings can be customized if needed)
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // Convert the EPUB stream to PDF applying the custom CSS
                Converter.ConvertEPUB(epubStream, config, pdfOptions, outputPdfPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF with custom CSS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}