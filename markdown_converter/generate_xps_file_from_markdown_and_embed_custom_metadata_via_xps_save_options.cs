// Generate an XPS file from a Markdown document and embed custom metadata via XpsSaveOptions.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string outputDir = Directory.GetCurrentDirectory();
            string sourcePath = Path.Combine(outputDir, "sample.md");
            string savePath = Path.Combine(outputDir, "output.xps");

            // Create sample markdown content and write to file
            string markdownContent = "# Hello World\nThis is a sample markdown.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown file to HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Initialize XPS save options with custom metadata
            XpsSaveOptions options = new XpsSaveOptions();
            options.BackgroundColor = Color.LightGray;      // Custom background color
            options.HorizontalResolution = 200;            // Custom horizontal DPI
            options.VerticalResolution = 200;              // Custom vertical DPI

            // Convert HTMLDocument to XPS file
            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}