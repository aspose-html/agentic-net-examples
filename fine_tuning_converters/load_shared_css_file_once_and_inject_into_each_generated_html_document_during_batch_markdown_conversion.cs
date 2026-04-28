// Load a shared CSS file once, then inject it into each generated HTML document during batch Markdown conversion.

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
            string cssPath = "style.css";
            string cssContent = File.ReadAllText(cssPath);

            string[] markdownFiles = Directory.GetFiles("markdown", "*.md");
            foreach (string mdPath in markdownFiles)
            {
                string markdownContent = File.ReadAllText(mdPath);
                var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdownContent));
                HTMLDocument document = Converter.ConvertMarkdown(stream, string.Empty);
                HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }
                HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
                styleElement.TextContent = cssContent;
                head.AppendChild(styleElement);
                string outputPath = Path.ChangeExtension(mdPath, ".html");
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