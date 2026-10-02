// Implement batch conversion of Markdown files to DOCX with individual DocSaveOptions for each file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Define markdown files and their contents
            var files = new (string Name, string Content)[]
            {
                ("Document1", "# Title 1\n\nThis is the first markdown document."),
                ("Document2", "# Title 2\n\nThis is the second markdown document."),
                ("Document3", "# Title 3\n\nThis is the third markdown document.")
            };

            for (int i = 0; i < files.Length; i++)
            {
                // Create source markdown file
                string sourcePath = Path.Combine(outputDir, files[i].Name + ".md");
                File.WriteAllText(sourcePath, files[i].Content);

                // Convert markdown to HTMLDocument
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

                // Prepare DOCX save options (individual per file)
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                // Example: set a different page size for each document
                int width = 800 + i * 100;
                int height = 600;
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(width, height),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                // Define output DOCX path
                string savePath = Path.Combine(outputDir, files[i].Name + ".docx");

                // Convert HTMLDocument to DOCX
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

                // Clean up
                document.Dispose();

                Console.WriteLine($"Converted '{sourcePath}' to '{savePath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}