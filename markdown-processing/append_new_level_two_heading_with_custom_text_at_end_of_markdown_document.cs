// Append a new level‑two heading with custom text at the end of the Markdown document.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Original markdown content
            string markdown = "# Sample Title\nThis is a sample markdown document.";
            // Append a level‑two heading in markdown
            string customHeading = "## Custom Heading";
            string updatedMarkdown = markdown + "\n\n" + customHeading;

            // Convert the updated markdown to an HTML document
            using (MemoryStream markdownStream = new MemoryStream(Encoding.UTF8.GetBytes(updatedMarkdown)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownStream, "utf-8");

                // Create a new level‑two heading element with custom text
                Aspose.Html.HTMLHeadingElement h2 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h2");
                h2.AppendChild(document.CreateTextNode("Appended Heading"));

                // Append the heading to the end of the document body
                document.Body.AppendChild(h2);

                // Save the resulting HTML to a file
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("HTML document saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}