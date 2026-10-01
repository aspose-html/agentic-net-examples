// Create a console application that watches a directory and converts new Markdown files to JPEG automatically.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "MarkdownInput");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "JpegOutput");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exists
            string sampleFile = Path.Combine(inputFolder, "sample.md");
            if (!File.Exists(sampleFile))
            {
                File.WriteAllText(sampleFile, "# Sample Markdown\n\nThis is a **test** markdown file.");
            }

            HashSet<string> processedFiles = new HashSet<string>();

            // Bounded polling loop (e.g., 5 iterations)
            for (int i = 0; i < 5; i++)
            {
                string[] markdownFiles = Directory.GetFiles(inputFolder, "*.md");
                foreach (string mdPath in markdownFiles)
                {
                    if (processedFiles.Contains(mdPath))
                        continue;

                    // Convert markdown to HTML document
                    HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath);

                    // Prepare JPEG save options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                    // Determine output JPEG path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".jpg");

                    // Perform conversion
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                    processedFiles.Add(mdPath);
                }

                Thread.Sleep(200);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}