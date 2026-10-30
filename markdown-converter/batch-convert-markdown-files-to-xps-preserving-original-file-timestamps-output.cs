// Batch convert Markdown files to XPS while preserving original file timestamps in the output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputXps";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Ensure at least one markdown file exists
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.md");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# Sample Markdown\n\nThis is a sample markdown file.");
            }

            string[] markdownFiles = Directory.GetFiles(inputFolder, "*.md");
            foreach (string sourcePath in markdownFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = Path.Combine(outputFolder, fileNameWithoutExt + ".xps");

                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                }

                // Preserve timestamps
                DateTime creation = File.GetCreationTime(sourcePath);
                DateTime lastWrite = File.GetLastWriteTime(sourcePath);
                DateTime lastAccess = File.GetLastAccessTime(sourcePath);
                File.SetCreationTime(savePath, creation);
                File.SetLastWriteTime(savePath, lastWrite);
                File.SetLastAccessTime(savePath, lastAccess);
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}