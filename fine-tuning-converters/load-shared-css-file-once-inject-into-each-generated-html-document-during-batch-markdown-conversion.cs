// Load a shared CSS file once, then inject it into each generated HTML document during batch Markdown conversion.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Shared CSS content
            string cssContent = "body { background-color: #f0f0f0; font-family: Arial, sans-serif; }";

            // Sample markdown inputs
            string[] markdownSources = new string[]
            {
                "# Document One\r\nThis is the first markdown document.",
                "# Document Two\r\nThis is the second markdown document."
            };

            // Output directory
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Base URI for conversion (required by API)
            string baseUri = "about:blank";

            for (int i = 0; i < markdownSources.Length; i++)
            {
                // Convert markdown string to HTMLDocument using a MemoryStream
                var markdownStream = new MemoryStream(Encoding.UTF8.GetBytes(markdownSources[i]));
                HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownStream, baseUri);

                // Ensure <head> element exists
                HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                // Create <style> element with shared CSS and append to <head>
                HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
                styleElement.TextContent = cssContent;
                head.AppendChild(styleElement);

                // Save HTML to file
                string outputPath = Path.Combine(outputDir, $"Document_{i + 1}.html");
                document.Save(outputPath);

                // Output result to console
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