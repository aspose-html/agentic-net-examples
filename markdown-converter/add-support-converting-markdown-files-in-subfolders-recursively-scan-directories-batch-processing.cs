// Add support for converting Markdown files located in subfolders by recursively scanning directories during batch processing.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputHtml";

            // Ensure input and output directories exist
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create sample markdown file in root
            string sampleRootPath = System.IO.Path.Combine(inputFolder, "sample.md");
            System.IO.File.WriteAllText(sampleRootPath, "# Sample\r\nHello World!");

            // Create subfolder and sample markdown file inside it
            string subFolder = System.IO.Path.Combine(inputFolder, "Sub");
            System.IO.Directory.CreateDirectory(subFolder);
            string sampleSubPath = System.IO.Path.Combine(subFolder, "subsample.md");
            System.IO.File.WriteAllText(sampleSubPath, "## Sub Sample\r\nThis is a subfolder markdown.");

            // Recursively process all markdown files
            foreach (string mdPath in System.IO.Directory.GetFiles(inputFolder, "*.md", System.IO.SearchOption.AllDirectories))
            {
                // Determine relative path to preserve folder structure in output
                string relativePath = mdPath.Substring(inputFolder.Length).TrimStart(System.IO.Path.DirectorySeparatorChar);
                string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.ChangeExtension(relativePath, ".html"));

                // Ensure the output directory exists
                string outputDir = System.IO.Path.GetDirectoryName(outputPath);
                if (!System.IO.Directory.Exists(outputDir))
                {
                    System.IO.Directory.CreateDirectory(outputDir);
                }

                // Convert markdown to HTML
                Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath, outputPath);
            }

            Console.WriteLine("Markdown conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}