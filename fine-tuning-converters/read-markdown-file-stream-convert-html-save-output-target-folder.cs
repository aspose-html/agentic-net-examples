// Read a Markdown file into a stream, convert to HTML, and save the output to a target folder.

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
            // Define paths
            string markdownPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.md");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);
            string htmlOutputPath = Path.Combine(outputDir, "sample.html");

            // Ensure sample markdown file exists
            if (!File.Exists(markdownPath))
            {
                string sampleContent = "# Hello World\n\nThis is a **markdown** sample.";
                File.WriteAllText(markdownPath, sampleContent, Encoding.UTF8);
            }

            // Read markdown file into a memory stream
            byte[] markdownBytes = File.ReadAllBytes(markdownPath);
            using (MemoryStream markdownStream = new MemoryStream(markdownBytes))
            {
                // Convert markdown stream to HTMLDocument
                using (HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownStream, "about:blank"))
                {
                    // Save HTML to file
                    document.Save(htmlOutputPath);
                }
            }

            Console.WriteLine("Conversion completed. HTML saved at " + htmlOutputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}