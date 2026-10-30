// Batch convert HTML to PDF, applying a header and footer on each page of the output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML files
            string[] inputFiles = new string[]
            {
                "sample1.html",
                "sample2.html"
            };

            // Ensure output directory exists
            string outputDir = "output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            foreach (string inputFile in inputFiles)
            {
                // Create a minimal HTML file with header and footer if it does not exist
                if (!File.Exists(inputFile))
                {
                    string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        @page {
            size: A4;
            margin: 1in;
            @top-center {
                content: 'Header - Page ' counter(page);
                font-size: 12pt;
                color: #555555;
            }
            @bottom-center {
                content: 'Footer - Page ' counter(page);
                font-size: 12pt;
                color: #555555;
            }
        }
        body {
            font-family: Arial, sans-serif;
        }
    </style>
</head>
<body>
    <h1>Sample Document</h1>
    <p>This is a sample paragraph to demonstrate header and footer on each PDF page.</p>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus.</p>
    <p>More content to create multiple pages when rendered to PDF.</p>
    <p>End of document.</p>
</body>
</html>";
                    File.WriteAllText(inputFile, htmlContent);
                }

                // Load HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputFile);

                // Prepare PDF save options (optional page setup)
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Define output PDF path
                string outputPdfPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputFile) + ".pdf");

                // Convert HTML to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);

                Console.WriteLine($"Converted '{inputFile}' to '{outputPdfPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}