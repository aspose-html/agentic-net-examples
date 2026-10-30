// Stream large Markdown files line by line into ConvertMarkdown to avoid loading the entire content into memory.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.md";
            string outputPath = "output.html";

            // Create a sample markdown file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "# Sample Title\n\nThis is a sample markdown file.\n\n- Item 1\n- Item 2\n");
            }

            // Open the markdown file as a stream to avoid loading the whole file into memory
            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Convert markdown stream to HTMLDocument
                HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "");

                // Ensure the document has a <head> element
                HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                // Add a simple style element
                HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
                styleElement.TextContent = "body { font-family: Arial; }";
                head.AppendChild(styleElement);

                // Save the resulting HTML to a file
                document.Save(outputPath);

                // Output the generated HTML and completion message
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