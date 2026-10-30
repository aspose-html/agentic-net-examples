// Inline external JavaScript files into script tags to create a single‑file HTML page.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample files
            string tempDir = Path.GetTempPath();
            string jsPath = Path.Combine(tempDir, "script.js");
            string htmlPath = Path.Combine(tempDir, "sample.html");
            string outputPath = Path.Combine(tempDir, "singlefile.html");

            File.WriteAllText(jsPath, "console.log('Hello from external script');");
            string htmlContent = $"<html><head><title>Test</title></head><body><script src=\"{Path.GetFileName(jsPath)}\"></script></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all script elements
            HTMLCollection scriptElements = document.GetElementsByTagName("script");

            // Inline external scripts
            for (int i = 0; i < scriptElements.Length; i++)
            {
                Element scriptElement = (Element)scriptElements[i];
                string src = scriptElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    string scriptFilePath = Path.Combine(Path.GetDirectoryName(htmlPath), src);
                    if (File.Exists(scriptFilePath))
                    {
                        string jsContent = File.ReadAllText(scriptFilePath);
                        HTMLElement htmlScript = (HTMLElement)scriptElement;
                        htmlScript.InnerHTML = jsContent;
                        scriptElement.RemoveAttribute("src");
                    }
                }
            }

            // Save as single-file HTML
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = ResourceHandling.Embed;
            document.Save(outputPath, options);

            Console.WriteLine("Single-file HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}