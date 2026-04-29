// Load a Markdown file from disk and convert it to an HTML file using ConvertMarkdown.

using System;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source Markdown file
            string sourcePath = "input.md";
            // Path where the resulting HTML file will be saved
            string outputPath = "output.html";

            // Convert the Markdown file to HTML and write the output file
            Converter.ConvertMarkdown(sourcePath, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}