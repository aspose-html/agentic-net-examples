// Create a custom CSS extension that adds a -aspose- page‑number footer, and verify in PDF output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PDF paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample Document</title>
</head>
<body>
    <h1>Sample Content</h1>
    <p>This document demonstrates a custom CSS extension for page numbers.</p>
    <p>Page content repeated to generate multiple pages.</p>
    <p style='page-break-before:always;'>Second page start.</p>
    <p>More content on the second page.</p>
</body>
</html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Create configuration and enable custom CSS extension via user stylesheet
            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = config.GetService<Aspose.Html.Services.IUserAgentService>();

            // Custom CSS that adds a footer with page number using Aspose extension
            string customCss = @"
@page {
    @bottom-center {
        content: '-aspose-page-number';
        font-size: 12pt;
        color: gray;
    }
}";
            userAgent.UserStyleSheet = customCss;

            // Load the HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);

            // Set PDF save options (default options are sufficient)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed successfully. Output file: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}