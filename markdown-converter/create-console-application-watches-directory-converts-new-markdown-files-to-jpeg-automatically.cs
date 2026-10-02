// Create a console application that watches a directory and converts new Markdown files to JPEG automatically.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputImages";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file
            string samplePath = Path.Combine(inputFolder, "sample.md");
            if (!File.Exists(samplePath))
            {
                File.WriteAllText(samplePath, "# Sample Markdown\n\nThis is a test.");
            }

            HashSet<string> processedFiles = new HashSet<string>();

            for (int i = 0; i < 5; i++)
            {
                string[] mdFiles = Directory.GetFiles(inputFolder, "*.md");
                foreach (string mdPath in mdFiles)
                {
                    if (!processedFiles.Contains(mdPath))
                    {
                        using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath))
                        {
                            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".jpg");
                            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        }
                        processedFiles.Add(mdPath);
                    }
                }
                Thread.Sleep(200);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}