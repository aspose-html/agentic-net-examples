// Append a new level‑two heading with custom text at the end of the Markdown document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input Markdown content
            string markdownContent = "# Sample Document\n\nThis is a sample markdown file.\n";

            // Convert Markdown to HTMLDocument
            using (MemoryStream mdStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdownContent)))
            {
                Aspose.Html.HTMLDocument doc = Aspose.Html.Converters.Converter.ConvertMarkdown(mdStream, "about:blank");

                // Create a level‑two heading (h2) with custom text
                Aspose.Html.HTMLHeadingElement h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
                h2.AppendChild(doc.CreateTextNode("Custom Level‑Two Heading"));

                // Append the heading to the end of the document body
                doc.Body.AppendChild(h2);

                // Define output path
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.md");

                // Save the modified document back to Markdown
                Aspose.Html.Saving.MarkdownSaveOptions saveOptions = new Aspose.Html.Saving.MarkdownSaveOptions();
                doc.Save(outputPath, saveOptions);

                Console.WriteLine("Markdown document saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}