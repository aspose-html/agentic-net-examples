// Add support for converting Markdown files located in subfolders by recursively scanning directories during batch processing.

using System;
using System.IO;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input folder containing markdown files and output folder for HTML files
            string inputFolder = @"C:\InputMarkdown";
            string outputFolder = @"C:\OutputHtml";

            // Ensure the output root folder exists
            Directory.CreateDirectory(outputFolder);

            // Recursively get all markdown files in the input folder and its subfolders
            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md", SearchOption.AllDirectories))
            {
                // Compute the relative path of the markdown file with respect to the input folder
                string relativePath = Path.GetRelativePath(inputFolder, mdPath);

                // Build the corresponding output HTML file path, preserving subfolder structure
                string outputPath = Path.Combine(outputFolder, Path.ChangeExtension(relativePath, ".html"));

                // Ensure the output subdirectory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Convert the markdown file to HTML and save it to the output path
                Converter.ConvertMarkdown(mdPath, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}