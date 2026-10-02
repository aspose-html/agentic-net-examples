// Batch convert HTML to PDF, applying a header and footer on each page of the output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define folders
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputPdf");

            // Ensure folders exist
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create sample HTML files if none exist
            string[] sampleFiles = new string[]
            {
                Path.Combine(inputFolder, "sample1.html"),
                Path.Combine(inputFolder, "sample2.html")
            };

            string sampleContent = "<html><body><h1>Sample Document</h1><p>This is a sample HTML file.</p></body></html>";

            foreach (string filePath in sampleFiles)
            {
                if (!File.Exists(filePath))
                    File.WriteAllText(filePath, sampleContent);
            }

            // Header and footer HTML (inline content)
            string headerHtml = "<html><body><div style='font-size:10pt; text-align:center;'>Header - My Document</div></body></html>";
            string footerHtml = "<html><body><div style='font-size:10pt; text-align:center;'>Footer - Page <span class='pageNumber'></span></div></body></html>";

            // Process each HTML file
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            foreach (string htmlPath in htmlFiles)
            {
                // Load main document from file
                HTMLDocument mainDoc = new HTMLDocument(htmlPath);

                // Load header and footer from inline HTML strings
                HTMLDocument headerDoc = new HTMLDocument(headerHtml, "about:blank");
                HTMLDocument footerDoc = new HTMLDocument(footerHtml, "about:blank");

                // Prepare renderer and options
                HtmlRenderer renderer = new HtmlRenderer();
                PdfRenderingOptions options = new PdfRenderingOptions();
                // Set page size (A4: 595x842 points)
                options.PageSetup.AnyPage = new Page(new Size(595, 842));
                // Optional: set background color
                options.BackgroundColor = System.Drawing.Color.White;

                // Define output PDF path
                string pdfPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");

                // Create PDF device
                PdfDevice device = new PdfDevice(options, pdfPath);

                // Render with header and footer
                renderer.Render(device, mainDoc, headerDoc, footerDoc);

                // Cleanup
                device.Dispose();
                mainDoc.Dispose();
                headerDoc.Dispose();
                footerDoc.Dispose();

                Console.WriteLine($"Converted '{Path.GetFileName(htmlPath)}' to PDF successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}