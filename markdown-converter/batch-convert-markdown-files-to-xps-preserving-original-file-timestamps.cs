// Batch convert Markdown files to XPS while preserving original file timestamps in the output.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "MarkdownFiles";
            string outputDir = "XpsOutput";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample markdown file if none exist
            string[] mdFiles = Directory.GetFiles(inputDir, "*.md");
            if (mdFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputDir, "sample.md");
                File.WriteAllText(samplePath, "# Sample Markdown\n\nThis is a sample markdown file.");
            }

            mdFiles = Directory.GetFiles(inputDir, "*.md");
            foreach (string sourcePath in mdFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = Path.Combine(outputDir, fileNameWithoutExt + ".xps");

                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
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

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}