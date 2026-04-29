// Batch convert Markdown files to XPS while preserving original file timestamps in the output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace BatchMarkdownToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDirectory = "MarkdownFiles";
                if (!Directory.Exists(inputDirectory))
                {
                    Console.WriteLine($"Input directory '{inputDirectory}' does not exist.");
                    return;
                }

                string[] markdownFiles = Directory.GetFiles(inputDirectory, "*.md", SearchOption.AllDirectories);
                foreach (string sourcePath in markdownFiles)
                {
                    string savePath = Path.ChangeExtension(sourcePath, ".xps");
                    Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                    DateTime lastWrite = File.GetLastWriteTime(sourcePath);
                    File.SetLastWriteTime(savePath, lastWrite);
                    DateTime creation = File.GetCreationTime(sourcePath);
                    File.SetCreationTime(savePath, creation);
                    Console.WriteLine($"Converted '{sourcePath}' to '{savePath}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}