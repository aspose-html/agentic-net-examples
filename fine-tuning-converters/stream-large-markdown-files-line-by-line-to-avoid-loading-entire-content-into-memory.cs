// Stream large Markdown files line by line into ConvertMarkdown to avoid loading the entire content into memory.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input markdown file and output HTML file paths
            string inputPath = "sample.md";
            string outputPath = "output.html";

            // Create a sample markdown file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "# Sample Markdown\n\nThis is a **test** markdown file.");
            }

            // Open a file stream for the markdown file (streamed, not fully loaded into memory)
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Convert markdown stream to HTMLDocument
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "");

                // Save the resulting HTML to a file
                document.Save(outputPath);

                // Output the generated HTML to console
                Console.WriteLine(document.DocumentElement.OuterHTML);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}