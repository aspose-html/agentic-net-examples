// Apply a custom Markdown header template via MarkdownSaveOptions.Template to format document titles uniformly.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.md";
            string outputPath = "output.html";

            // Create a minimal markdown file
            string markdownContent = "# Sample Title\n\nThis is a sample markdown document.";
            File.WriteAllText(sourcePath, markdownContent, Encoding.UTF8);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Ensure the document has a <head> element
            Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            // Add a custom style template for headers
            Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
            styleElement.TextContent = "h1 { font-family: Arial, sans-serif; color: #333333; }";
            head.AppendChild(styleElement);

            // Save the resulting HTML
            document.Save(outputPath);

            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}