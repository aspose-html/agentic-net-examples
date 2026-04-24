// Read HTML content from standard input or file, convert it to MHTML using Converter.ConvertHTML, and save the output as an .mhtml file.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Path to the source HTML file (first argument or default)
            string sourcePath = args.Length > 0 ? args[0] : "input.html";

            // Path where the resulting MHTML file will be saved (second argument or default)
            string outputPath = args.Length > 1 ? args[1] : "output.mhtml";

            // Load the HTML document from the specified file
            HTMLDocument document = new HTMLDocument(sourcePath);

            // Create default MHTML save options
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Convert the HTML document to MHTML and write to the output file
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}