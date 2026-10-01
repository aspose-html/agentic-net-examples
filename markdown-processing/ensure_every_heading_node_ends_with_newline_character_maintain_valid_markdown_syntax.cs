// Ensure every heading node ends with a newline character to maintain valid Markdown syntax.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define output HTML file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            // Create an HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = document.Body;

            // Add a heading
            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            h1.AppendChild(document.CreateTextNode("Sample Heading"));
            body.AppendChild(h1);

            // Add a paragraph
            Aspose.Html.HTMLParagraphElement p = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            p.AppendChild(document.CreateTextNode("This is a sample paragraph."));
            body.AppendChild(p);

            // Save the HTML document
            document.Save(outputPath);

            // Read HTML content for conversion
            string htmlContent = File.ReadAllText(outputPath);
            string baseUri = "file:///" + outputPath.Replace("\\", "/");

            // Set Markdown conversion options
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();

            // Convert HTML to Markdown using a temporary file
            string tempPath = Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            // Ensure the heading line ends with a newline character
            if (markdown.StartsWith("# "))
            {
                int firstLineEnd = markdown.IndexOf('\n');
                if (firstLineEnd == -1)
                {
                    markdown += Environment.NewLine;
                }
                else if (firstLineEnd == markdown.Length - 1)
                {
                    // Already ends with newline
                }
                else
                {
                    // Ensure there is a newline after the heading line
                    markdown = markdown.Insert(firstLineEnd + 1, string.Empty);
                }
            }

            // Output results
            Console.WriteLine("Generated Markdown:");
            Console.WriteLine(markdown);
            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}