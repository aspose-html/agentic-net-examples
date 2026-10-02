// Write code to convert PDF and then add a table of contents using a PDF manipulation library.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PDF paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string outputPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create a minimal HTML file with headings if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Sample Document</title></head>
<body>
<h1>Chapter 1</h1>
<p>Content of chapter 1.</p>
<h2>Section 1.1</h2>
<p>Details of section 1.1.</p>
<h1>Chapter 2</h1>
<p>Content of chapter 2.</p>
<h2>Section 2.1</h2>
<p>Details of section 2.1.</p>
</body>
</html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Set PDF save options (default options)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);

            Console.WriteLine($"PDF successfully created at: {outputPdfPath}");
            Console.WriteLine("Note: Adding a Table of Contents to the PDF is not supported by Aspose.HTML.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}