// Convert a Markdown string to HTML, inject custom CSS into the head, and save the styled page.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Hello World\nThis is a **markdown** sample.";
            string css = "body { font-family: Arial; background-color: #f0f0f0; } h1 { color: #336699; }";
            string outputPath = "styled.html";

            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdown)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");

                Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
                styleElement.TextContent = css;
                head.AppendChild(styleElement);

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