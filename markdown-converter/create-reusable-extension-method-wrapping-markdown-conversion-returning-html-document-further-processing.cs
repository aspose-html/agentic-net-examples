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
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));
            return Aspose.Html.Converters.Converter.ConvertMarkdown(stream, baseUri);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                string markdown = "# Sample Title\n\nThis is a **markdown** example.";
                Aspose.Html.HTMLDocument document = markdown.ToHtmlDocument();

                Console.WriteLine(document.DocumentElement.OuterHTML);
                Console.WriteLine("Markdown conversion to HTMLDocument completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}