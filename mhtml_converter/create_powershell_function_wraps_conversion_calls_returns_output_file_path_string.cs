// Create a PowerShell function that wraps conversion calls and returns the output file path as a string.

using System;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the markdown source file
            string sourcePath = "input.md";
            // Desired path for the generated HTML file
            string outputPath = "output.html";

            // Perform conversion and obtain the output file path
            string resultPath = ConvertMarkdownToHtml(sourcePath, outputPath);
            Console.WriteLine($"Conversion succeeded. Output file: {resultPath}");
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during conversion
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }

    // Wraps the Aspose.HTML conversion call and returns the output file path
    static string ConvertMarkdownToHtml(string sourcePath, string outputPath)
    {
        // Convert the markdown file to HTML and save it to the specified location
        Converter.ConvertMarkdown(sourcePath, outputPath);
        return outputPath;
    }
}