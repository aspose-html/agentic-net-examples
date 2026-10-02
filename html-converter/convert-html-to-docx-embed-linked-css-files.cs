// Convert HTML to DOCX while embedding all linked CSS files into the resulting document.

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
            // Prepare sample HTML and CSS files
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            Directory.CreateDirectory(dataDir);
            string htmlPath = Path.Combine(dataDir, "sample.html");
            string cssPath = Path.Combine(dataDir, "style.css");
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><h1>Hello World</h1></body></html>");
            }
            if (!File.Exists(cssPath))
            {
                File.WriteAllText(cssPath, "h1 { color: red; }");
            }

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Ensure <head> exists
            HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            // Embed linked CSS files
            var linkElements = document.QuerySelectorAll("link[rel='stylesheet']");
            foreach (var node in linkElements)
            {
                HTMLLinkElement link = node as HTMLLinkElement;
                if (link != null && !string.IsNullOrEmpty(link.Href))
                {
                    string cssFilePath = Path.Combine(dataDir, link.Href);
                    if (File.Exists(cssFilePath))
                    {
                        string cssContent = File.ReadAllText(cssFilePath);
                        HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
                        styleElement.TextContent = cssContent;
                        head.AppendChild(styleElement);
                    }
                }
                // Optionally remove the original link element
                link.ParentNode.RemoveChild(link);
            }

            // Convert to DOCX
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.docx");
            DocSaveOptions saveOptions = new DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, outputPath);

            Console.WriteLine("Conversion completed. DOCX saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}