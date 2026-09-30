// Stream large Markdown files line by line into ConvertMarkdown to avoid loading the entire content into memory.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample markdown file
            string inputPath = "sample.md";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string[] lines = new string[]
                {
                    "# Sample Markdown",
                    "",
                    "This is a **bold** text.",
                    "",
                    "- Item 1",
                    "- Item 2",
                    "- Item 3",
                    "",
                    "```csharp",
                    "Console.WriteLine(\"Hello, World!\");",
                    "```"
                };
                File.WriteAllLines(inputPath, lines);
            }

            // Open file stream for markdown content (streaming, no full load)
            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Convert markdown to HTMLDocument
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "");

                // Ensure <head> element exists
                Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                // Add a simple style element
                Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
                styleElement.TextContent = "body { font-family: Arial, sans-serif; margin: 20px; }";
                head.AppendChild(styleElement);

                // Save the resulting HTML
                document.Save(outputPath);

                // Output results
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