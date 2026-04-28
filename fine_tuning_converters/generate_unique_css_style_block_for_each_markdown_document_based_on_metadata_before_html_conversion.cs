// Generate a unique CSS style block for each Markdown document based on its metadata before HTML conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string markdownContent = "# Sample Document\nThis is a sample markdown.";
            string metadata = "SampleDocument";
            string cssContent = $"/* Style for {metadata} */\nbody {{ color: #333; }}";
            string baseUri = "";
            string outputPath = "output.html";

            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdownContent));
            HTMLDocument document = Converter.ConvertMarkdown(stream, baseUri);
            HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }
            HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
            styleElement.TextContent = cssContent;
            head.AppendChild(styleElement);
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