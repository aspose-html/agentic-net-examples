// Save the converted website HTML to a specified output directory preserving original folder structure.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input folder containing the website HTML files
            string inputFolder = @"C:\InputWebsite";
            // Output folder where converted files will be saved
            string outputFolder = @"C:\OutputWebsite";

            // Ensure the output root folder exists
            Directory.CreateDirectory(outputFolder);

            // Process all .html files recursively
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories))
            {
                // Determine relative path to preserve folder structure
                string relativePath = Path.GetRelativePath(inputFolder, htmlPath);
                string relativeDir = Path.GetDirectoryName(relativePath);

                // Create corresponding directory in the output folder
                string targetDir = Path.Combine(outputFolder, relativeDir ?? string.Empty);
                Directory.CreateDirectory(targetDir);

                // Build output file path with .mht extension
                string outputPath = Path.Combine(targetDir, Path.GetFileNameWithoutExtension(htmlPath) + ".mht");

                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Set default MHTML save options
                    MHTMLSaveOptions options = new MHTMLSaveOptions();

                    // Convert and save the document as MHTML
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}