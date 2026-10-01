// Create a reusable extension method that wraps ConvertMarkdown and returns an HTMLDocument for further processing.

using System;
using System.IO;
using System.Text;

namespace AsposeHtmlMarkdownExample
{
    public static class MarkdownExtensions
    {
        public static Aspose.Html.HTMLDocument ConvertToHtmlDocument(this string markdown, string baseUri)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, baseUri);
                return document;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                string markdownContent = "# Sample Title\n\nThis is a **markdown** sample.";
                string baseUri = "http://example.com";

                Aspose.Html.HTMLDocument document = markdownContent.ConvertToHtmlDocument(baseUri);

                // Ensure <head> exists
                Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                // Add simple style
                Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
                styleElement.TextContent = "body { font-family: Arial, sans-serif; margin: 20px; }";
                head.AppendChild(styleElement);

                // Save the result
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);

                Console.WriteLine(document.DocumentElement.OuterHTML);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}