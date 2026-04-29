// Convert a collection of Markdown strings to individual PNG files using parallel processing.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MarkdownToPngParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> markdownContents = new List<string>
                {
                    "# Title 1\nSome **bold** text.",
                    "## Title 2\n- Item 1\n- Item 2",
                    "Plain text without markdown."
                };

                string tempDir = Path.Combine(Path.GetTempPath(), "MarkdownToPng");
                Directory.CreateDirectory(tempDir);
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "OutputPng");
                Directory.CreateDirectory(outputDir);

                List<(string sourcePath, string outputPath)> files = new List<(string, string)>();

                for (int i = 0; i < markdownContents.Count; i++)
                {
                    string sourcePath = Path.Combine(tempDir, $"doc{i}.md");
                    File.WriteAllText(sourcePath, markdownContents[i]);
                    string outputPath = Path.Combine(outputDir, $"doc{i}.png");
                    files.Add((sourcePath, outputPath));
                }

                Parallel.ForEach(files, filePair =>
                {
                    try
                    {
                        string sourcePath = filePair.sourcePath;
                        Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                        string savePath = filePair.outputPath;
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing {filePair.sourcePath}: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error: {ex.Message}");
            }
        }
    }
}