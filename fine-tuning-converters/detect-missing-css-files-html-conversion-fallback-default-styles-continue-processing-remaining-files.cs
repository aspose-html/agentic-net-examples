// Detect missing CSS files during HTML conversion, fallback to default styles, and continue processing remaining files.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "input");
            Directory.CreateDirectory(inputDir);
            string htmlPath = Path.Combine(inputDir, "sample.html");
            string cssPath = Path.Combine(inputDir, "style1.css");
            // Create a CSS file that exists
            File.WriteAllText(cssPath, "body { background-color: lightgreen; }");
            // Create HTML that references an existing and a missing CSS file
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" href=""style1.css"">
    <link rel=""stylesheet"" href=""missing.css"">
</head>
<body>
    <h1>Hello World</h1>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Process linked CSS files
            var linkElements = document.GetElementsByTagName("link");
            for (int i = 0; i < linkElements.Length; i++)
            {
                var link = linkElements[i] as HTMLElement;
                if (link == null) continue;
                var rel = link.GetAttribute("rel");
                var href = link.GetAttribute("href");
                if (string.Equals(rel, "stylesheet", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(href))
                {
                    string cssFullPath = Path.Combine(inputDir, href);
                    if (!File.Exists(cssFullPath))
                    {
                        // Missing CSS – inject default style
                        var styleElement = (HTMLElement)document.CreateElement("style");
                        styleElement.InnerHTML = "body { font-family: Arial, sans-serif; color: #333333; }";
                        var head = document.GetElementsByTagName("head")[0] as HTMLElement;
                        head?.AppendChild(styleElement);
                        // Optionally remove the broken link element
                        link.ParentNode.RemoveChild(link);
                    }
                }
            }

            // Convert to XPS
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "sample.xps");
            XpsSaveOptions options = new XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}