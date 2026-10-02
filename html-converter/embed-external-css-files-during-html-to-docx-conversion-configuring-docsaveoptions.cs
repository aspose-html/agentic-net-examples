// Embed external CSS files during HTML to DOCX conversion by configuring DocSaveOptions accordingly.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input HTML and CSS files
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            Directory.CreateDirectory(dataDir);

            string cssPath = Path.Combine(dataDir, "style.css");
            File.WriteAllText(cssPath, "body { font-family: Arial; color: blue; }");

            string htmlPath = Path.Combine(dataDir, "sample.html");
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" type=""text/css"" href=""style.css"">
    <title>Sample</title>
</head>
<body>
    <h1>Hello, Aspose.HTML!</h1>
    <p>This paragraph should be styled by external CSS.</p>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Prepare output path
            string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "result.docx");

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure save options (default options are sufficient for embedding resources)
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Convert HTML to DOCX
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}