// Convert HTML to DOCX while embedding all linked CSS files into the resulting document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // Create sample CSS file
            string cssFileName = "style.css";
            string cssPath = Path.Combine(dataDir, cssFileName);
            string cssContent = "body { font-family: Arial; color: #333333; } h1 { color: #0066CC; }";
            File.WriteAllText(cssPath, cssContent);

            // Create sample HTML file with a linked stylesheet
            string htmlFileName = "sample.html";
            string htmlPath = Path.Combine(dataDir, htmlFileName);
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8' />
    <title>Sample Document</title>
    <link rel='stylesheet' href='style.css' />
</head>
<body>
    <h1>Hello, Aspose.HTML!</h1>
    <p>This is a sample paragraph.</p>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, dataDir);

            // Ensure <head> exists
            Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            // Embed linked CSS content
            string linkedCss = File.ReadAllText(cssPath);
            Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
            styleElement.TextContent = linkedCss;
            head.AppendChild(styleElement);

            // Convert to DOCX
            string outputPath = Path.Combine(outputDir, "Result.docx");
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. DOCX saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}