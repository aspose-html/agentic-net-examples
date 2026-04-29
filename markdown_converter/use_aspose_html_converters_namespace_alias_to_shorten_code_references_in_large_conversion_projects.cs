// Use the Aspose.Html.Converters namespace alias to shorten code references in large conversion projects.

using System;
using C = Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source Markdown file
            string sourcePath = "input.md";

            // Desired path for the generated HTML file
            string outputPath = "output.html";

            // Convert Markdown to HTML using the alias for Aspose.Html.Converters
            C.Converter.ConvertMarkdown(sourcePath, outputPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}