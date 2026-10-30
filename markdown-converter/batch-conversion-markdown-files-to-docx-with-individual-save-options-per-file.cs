// Implement batch conversion of Markdown files to DOCX with individual DocSaveOptions for each file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string currentDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(currentDir, "Input");
            string outputDir = Path.Combine(currentDir, "Output");

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create sample markdown files if they do not exist
            string[] sampleFiles = { "doc1.md", "doc2.md" };
            string sampleContent = "# Sample Document\n\nThis is a **markdown** file generated for conversion.";

            foreach (string fileName in sampleFiles)
            {
                string filePath = Path.Combine(inputDir, fileName);
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, sampleContent);
                }
            }

            // Batch conversion of each markdown file to DOCX with individual DocSaveOptions
            string[] markdownFiles = Directory.GetFiles(inputDir, "*.md");
            foreach (string sourcePath in markdownFiles)
            {
                // Load markdown and convert to HTMLDocument
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

                // Create a new DocSaveOptions instance for this file
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                // Define output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = Path.Combine(outputDir, fileNameWithoutExt + "-output.docx");

                // Convert HTMLDocument to DOCX
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

                Console.WriteLine($"Converted '{Path.GetFileName(sourcePath)}' to '{Path.GetFileName(savePath)}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}