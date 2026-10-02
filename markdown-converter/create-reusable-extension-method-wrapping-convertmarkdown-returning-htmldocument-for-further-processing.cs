// Create a reusable extension method that wraps ConvertMarkdown and returns an HTMLDocument for further processing.

using System;
using System.IO;
using System.Text;

namespace AsposeHtmlMarkdownExample
{
    public static class MarkdownExtensions
    {
        public static Aspose.Html.HTMLDocument ToHtmlDocument(this string markdown, string baseUri = "about:blank")
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
            {
                return Aspose.Html.Converters.Converter.ConvertMarkdown(stream, baseUri);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                string markdown = "# Sample Heading\nThis is a **markdown** sample.";
                Aspose.Html.HTMLDocument document = markdown.ToHtmlDocument();

                Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
                styleElement.TextContent = "body { font-family: Arial, sans-serif; margin: 20px; }";
                head.AppendChild(styleElement);

                string outputPath = "output.html";
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