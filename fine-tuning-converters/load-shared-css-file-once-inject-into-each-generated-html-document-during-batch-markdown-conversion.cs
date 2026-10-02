// Load a shared CSS file once, then inject it into each generated HTML document during batch Markdown conversion.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare shared CSS
            string cssPath = "shared.css";
            if (!File.Exists(cssPath))
            {
                File.WriteAllText(cssPath, "body { font-family: Arial; margin: 20px; }");
            }
            string cssContent = File.ReadAllText(cssPath);

            // Prepare sample markdown files
            string[] markdownFiles = new string[] { "doc1.md", "doc2.md" };
            string[] markdownContents = new string[]
            {
                "# Document 1\r\nThis is the *first* document.",
                "# Document 2\r\nThis is the **second** document."
            };

            for (int i = 0; i < markdownFiles.Length; i++)
            {
                if (!File.Exists(markdownFiles[i]))
                {
                    File.WriteAllText(markdownFiles[i], markdownContents[i]);
                }
            }

            // Output directory
            string outputDir = "output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Batch conversion
            foreach (string mdPath in markdownFiles)
            {
                // Convert markdown to HTMLDocument
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath);

                // Ensure <head> exists
                Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                // Create <style> element with shared CSS
                Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
                styleElement.TextContent = cssContent;
                head.AppendChild(styleElement);

                // Save HTML
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(mdPath) + ".html");
                document.Save(outputPath);

                // Output to console
                Console.WriteLine(document.DocumentElement.OuterHTML);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}