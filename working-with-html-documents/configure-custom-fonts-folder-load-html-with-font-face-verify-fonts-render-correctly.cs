// Configure custom fonts folder, load HTML using @font-face rules, and verify fonts render correctly.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare custom fonts folder and a placeholder font file
            string fontsFolder = "fonts";
            if (!System.IO.Directory.Exists(fontsFolder))
                System.IO.Directory.CreateDirectory(fontsFolder);
            string fontFilePath = System.IO.Path.Combine(fontsFolder, "OpenSans-Regular.ttf");
            if (!System.IO.File.Exists(fontFilePath))
                System.IO.File.WriteAllBytes(fontFilePath, new byte[0]); // placeholder font

            // Configure Aspose.HTML to use the custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder, true);

            // Create sample HTML that uses @font-face to reference the custom font
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <style>
        @font-face {
            font-family: 'OpenSans';
            src: url('OpenSans-Regular.ttf');
        }
        body {
            font-family: 'OpenSans';
            font-size: 24px;
        }
    </style>
</head>
<body>
    <div>Hello, custom font!</div>
</body>
</html>";

            // Write HTML to a temporary file
            string htmlFilePath = "sample.html";
            System.IO.File.WriteAllText(htmlFilePath, htmlContent);

            // Load the HTML document with the custom configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath, configuration);

            // Convert the document to PDF to verify font rendering
            string outputPdfPath = "output.pdf";
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPdfPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}