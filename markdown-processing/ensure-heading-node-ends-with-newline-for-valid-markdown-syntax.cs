// Ensure every heading node ends with a newline character to maintain valid Markdown syntax.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML document
            HTMLDocument doc = new HTMLDocument();
            HTMLElement body = doc.Body;

            HTMLHeadingElement h1 = (HTMLHeadingElement)doc.CreateElement("h1");
            h1.AppendChild(doc.CreateTextNode("Sample Heading"));
            HTMLParagraphElement p = (HTMLParagraphElement)doc.CreateElement("p");
            p.AppendChild(doc.CreateTextNode("Sample paragraph."));

            body.AppendChild(h1);
            body.AppendChild(p);

            string htmlPath = "output.html";
            doc.Save(htmlPath);
            Console.WriteLine("HTML saved at " + htmlPath);

            // Load HTML content for conversion
            string htmlContent = File.ReadAllText(htmlPath);
            string baseUri = "about:blank";

            // Convert HTML to Markdown
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            // Ensure each heading ends with an extra newline
            string[] lines = markdown.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                sb.AppendLine(line);
                if (line.StartsWith("#"))
                {
                    sb.AppendLine();
                }
            }
            string finalMarkdown = sb.ToString();

            string markdownPath = "output.md";
            File.WriteAllText(markdownPath, finalMarkdown);
            Console.WriteLine("Conversion completed. Markdown saved at " + markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}