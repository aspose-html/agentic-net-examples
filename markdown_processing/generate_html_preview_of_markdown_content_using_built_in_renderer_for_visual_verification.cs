// Generate an HTML preview of the Markdown content using the built‑in renderer for visual verification.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string markdownContent = "# Sample Title\n\nThis is a **markdown** preview.";
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdownContent));
            HTMLDocument document = Converter.ConvertMarkdown(stream, "");
            HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }
            HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
            styleElement.TextContent = "body { font-family: Arial; }";
            head.AppendChild(styleElement);
            string outputPath = "preview.html";
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