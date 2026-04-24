// Implement error handling for missing HTML source files when invoking Converter.ConvertHTML with file paths.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        // Path to the source HTML file
        string sourcePath = "input.html";
        // Desired output XPS file path
        string outputPath = "output.xps";

        try
        {
            // Load the HTML document from the file system
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            // Create default XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.IO.FileNotFoundException fnfEx)
        {
            // Handle missing source file
            Console.WriteLine($"HTML source file not found: {fnfEx.FileName}");
        }
        catch (Exception ex)
        {
            // Handle any other errors
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}