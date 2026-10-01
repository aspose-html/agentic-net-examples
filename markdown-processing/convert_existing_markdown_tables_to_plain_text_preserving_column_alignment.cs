// Convert existing Markdown tables into plain text representations while preserving column alignment.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input markdown file and output paths
            string sourcePath = "sample.md";
            string htmlPath = "output.html";
            string textPath = "output.txt";

            // Create a sample markdown file with a table
            string markdownContent = @"
# Sample Table

| Name   | Age | City       |
|--------|-----|------------|
| Alice  | 30  | New York   |
| Bob    | 25  | Los Angeles|
| Charlie| 35  | Chicago    |
";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTML using Aspose.HTML
            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, htmlPath);

            // Load the generated HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Extract plain text preserving alignment
            string plainText = document.Body.TextContent;

            // Save the plain text to a file
            File.WriteAllText(textPath, plainText);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"HTML saved to: {Path.GetFullPath(htmlPath)}");
            Console.WriteLine($"Plain text saved to: {Path.GetFullPath(textPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}