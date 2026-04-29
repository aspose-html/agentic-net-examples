// Implement a command‑line tool that accepts a Markdown file path and outputs an HTML file.

using System;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Verify that at least the markdown source path is provided
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: <app> <markdownFilePath> [outputHtmlPath]");
                return;
            }

            // Source markdown file path (provided by the user)
            string sourcePath = args[0];

            // Determine output HTML file path; use second argument if supplied,
            // otherwise replace the source file extension with .html
            string outputPath = args.Length >= 2
                ? args[1]
                : System.IO.Path.ChangeExtension(sourcePath, ".html");

            // Convert the markdown file to HTML and write the result to the output path
            Converter.ConvertMarkdown(sourcePath, outputPath);

            Console.WriteLine($"Conversion successful: '{sourcePath}' -> '{outputPath}'");
        }
        catch (Exception ex)
        {
            // Report any errors that occur during conversion
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}