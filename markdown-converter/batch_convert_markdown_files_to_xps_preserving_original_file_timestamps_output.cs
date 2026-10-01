// Batch convert Markdown files to XPS while preserving original file timestamps in the output.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.md");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# Sample Markdown\n\nThis is a *sample* markdown file.");
            }

            string[] markdownFiles = Directory.GetFiles(inputFolder, "*.md");
            foreach (string sourcePath in markdownFiles)
            {
                try
                {
                    string savePath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(sourcePath) + ".xps");

                    using (Aspose.Html.HTMLDocument document =
                        Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
                    {
                        Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                    }

                    // Preserve timestamps
                    DateTime creationTime = File.GetCreationTime(sourcePath);
                    DateTime lastWriteTime = File.GetLastWriteTime(sourcePath);
                    DateTime lastAccessTime = File.GetLastAccessTime(sourcePath);

                    File.SetCreationTime(savePath, creationTime);
                    File.SetLastWriteTime(savePath, lastWriteTime);
                    File.SetLastAccessTime(savePath, lastAccessTime);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file '{sourcePath}': {ex.Message}");
                }
            }

            Console.WriteLine("Batch conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}