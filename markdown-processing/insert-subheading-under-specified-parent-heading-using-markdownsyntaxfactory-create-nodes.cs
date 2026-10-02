// Insert a subheading under a specified parent heading using the MarkdownSyntaxFactory to create nodes.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Build markdown content
            var markdownBuilder = new StringBuilder();
            markdownBuilder.AppendLine("# Parent Heading");
            markdownBuilder.AppendLine("## Subheading");
            string markdown = markdownBuilder.ToString();

            // Convert markdown to HTML document
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");

                // Save the resulting HTML
                string outputPath = "output.html";
                document.Save(outputPath);

                // Output result to console
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