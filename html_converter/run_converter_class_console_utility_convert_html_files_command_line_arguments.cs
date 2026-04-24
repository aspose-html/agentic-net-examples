// Run the Converter class in a console utility to convert HTML files supplied via command‑line arguments.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide at least one HTML file path as an argument.");
                return;
            }

            foreach (string sourcePath in args)
            {
                // Validate source file existence
                if (!File.Exists(sourcePath))
                {
                    Console.WriteLine($"File not found: {sourcePath}");
                    continue;
                }

                // Determine output DOCX path (same folder, same name with .docx extension)
                string outputPath = Path.ChangeExtension(sourcePath, ".docx");

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(sourcePath);

                // Create default DOCX save options
                DocSaveOptions options = new DocSaveOptions();

                // Perform conversion
                Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine($"Converted '{sourcePath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}