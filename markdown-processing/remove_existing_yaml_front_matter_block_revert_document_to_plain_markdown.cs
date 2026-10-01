// Remove an existing YAML front‑matter block to revert the document to plain Markdown.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.md";
            string outputPath = "output.md";
            string htmlOutputPath = "output.html";

            // Create a sample markdown file with YAML front‑matter if it does not exist
            if (!File.Exists(inputPath))
            {
                string sample = "---\ntitle: Sample Document\nauthor: Aspose\n---\n\n# Hello World\nThis is a sample markdown file.";
                File.WriteAllText(inputPath, sample, Encoding.UTF8);
            }

            // Read the markdown content
            string content = File.ReadAllText(inputPath, Encoding.UTF8);

            // Remove YAML front‑matter block (delimited by lines containing only "---")
            int startIdx = content.IndexOf("---");
            if (startIdx != -1)
            {
                int endIdx = content.IndexOf("---", startIdx + 3);
                if (endIdx != -1)
                {
                    // Include the line break after the closing delimiter
                    int afterEnd = content.IndexOf('\n', endIdx);
                    if (afterEnd == -1) afterEnd = content.Length;
                    else afterEnd += 1; // include newline
                    content = content.Remove(startIdx, afterEnd - startIdx);
                }
            }

            // Save the cleaned markdown
            File.WriteAllText(outputPath, content, Encoding.UTF8);
            Console.WriteLine("Cleaned markdown saved to: " + outputPath);

            // Convert cleaned markdown to HTML using Aspose.Html
            using (MemoryStream markdownStream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                HTMLDocument htmlDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownStream, "");
                htmlDoc.Save(htmlOutputPath);
                Console.WriteLine("Converted HTML saved to: " + htmlOutputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}