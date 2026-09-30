// Load a shared CSS file once, then inject it into each generated HTML document during batch Markdown conversion.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            // Load shared CSS once
            string cssPath = "style.css";
            if (!File.Exists(cssPath))
            {
                File.WriteAllText(cssPath, "body { font-family: Arial; }");
            }
            string cssContent = File.ReadAllText(cssPath);

            // Define markdown files for batch conversion
            string[] markdownFiles = new string[] { "doc1.md", "doc2.md" };
            string sampleMarkdown = "# Sample Document\r\nThis is a sample markdown.";
            foreach (var mdPath in markdownFiles)
            {
                if (!File.Exists(mdPath))
                {
                    File.WriteAllText(mdPath, sampleMarkdown);
                }
            }

            // Process each markdown file
            foreach (var mdPath in markdownFiles)
            {
                string markdown = File.ReadAllText(mdPath);
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));

                // Convert markdown to HTMLDocument
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, string.Empty);

                // Ensure <head> element exists
                Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                // Inject shared CSS into <style> element
                Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
                styleElement.TextContent = cssContent;
                head.AppendChild(styleElement);

                // Save the resulting HTML
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(mdPath) + ".html");
                document.Save(outputPath);

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