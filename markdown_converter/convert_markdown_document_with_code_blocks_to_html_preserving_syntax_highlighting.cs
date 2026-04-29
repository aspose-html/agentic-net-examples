// Convert a Markdown document containing code blocks to an HTML file preserving syntax highlighting.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

namespace MarkdownToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input markdown file path (first argument) and output HTML file path (second argument)
                string inputPath = args.Length > 0 ? args[0] : "input.md";
                string outputPath = args.Length > 1 ? args[1] : "output.html";

                // Read markdown content from file
                string markdownContent = File.ReadAllText(inputPath);

                // Create a memory stream containing the markdown bytes
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(markdownContent)))
                {
                    // Convert markdown stream to an HTMLDocument
                    HTMLDocument document = Converter.ConvertMarkdown(stream, string.Empty);

                    // Ensure the document has a <head> element
                    HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
                    if (head == null)
                    {
                        head = document.CreateElement("head") as HTMLHeadElement;
                        document.DocumentElement.AppendChild(head);
                    }

                    // Create a <style> element with CSS for syntax highlighting
                    HTMLStyleElement style = document.CreateElement("style") as HTMLStyleElement;
                    style.TextContent = @"
code { background:#f5f5f5; padding:2px 4px; border-radius:4px; }
pre { background:#f5f5f5; padding:10px; overflow:auto; }
pre code { background:transparent; padding:0; }
";

                    // Append the style element to the head
                    head.AppendChild(style);

                    // Save the resulting HTML to the specified output path
                    document.Save(outputPath);
                }

                Console.WriteLine($"Conversion completed. HTML saved at {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}