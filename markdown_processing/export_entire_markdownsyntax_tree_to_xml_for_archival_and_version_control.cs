// Export the entire MarkdownSyntaxTree to an XML file for archival and version control purposes.

using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string markdownPath = "input.md";
            string xmlPath = "markdown.xml";

            // Convert Markdown to an HTMLDocument using Aspose.HTML
            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            // Retrieve the HTML representation (optional, can be used for further processing)
            string htmlContent = document.ToString();

            // Create an XML document representing the original Markdown syntax tree
            XDocument xmlDoc = new XDocument(
                new XElement("MarkdownSyntaxTree",
                    new XCData(File.ReadAllText(markdownPath))
                )
            );

            // Save the XML to the specified file
            xmlDoc.Save(xmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}