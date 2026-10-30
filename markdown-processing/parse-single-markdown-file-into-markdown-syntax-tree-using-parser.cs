// Parse a single Markdown file into a MarkdownSyntaxTree using the MarkdownParser class.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample markdown file
            string sourcePath = "sample.md";
            File.WriteAllText(sourcePath, "# Hello World\nThis is a sample markdown.");

            // Convert markdown to HTML
            string outputPath = "sample.html";
            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, outputPath);

            // Display result
            Console.WriteLine($"Markdown file '{sourcePath}' was converted to HTML at '{outputPath}'.");
            Console.WriteLine("Converted HTML content:");
            Console.WriteLine(File.ReadAllText(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}