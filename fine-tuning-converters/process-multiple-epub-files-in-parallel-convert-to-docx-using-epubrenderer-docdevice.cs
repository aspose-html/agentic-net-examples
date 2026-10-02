// Process multiple EPUB files in parallel, converting each to DOCX using EpubRenderer and DocDevice.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputDocs";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Sample EPUB file paths (replace with actual files)
            List<string> epubFiles = new List<string>
            {
                Path.Combine(inputDir, "sample1.epub"),
                Path.Combine(inputDir, "sample2.epub")
            };

            Parallel.ForEach(epubFiles, epubPath =>
            {
                try
                {
                    using (FileStream stream = File.OpenRead(epubPath))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(epubPath);
                        string outputPath = Path.Combine(outputDir, fileName + ".docx");

                        var renderingOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

                        using (var device = new Aspose.Html.Rendering.Doc.DocDevice(renderingOptions, outputPath))
                        {
                            var renderer = new Aspose.Html.Rendering.EpubRenderer();
                            renderer.Render(device, stream);
                        }
                    }

                    Console.WriteLine($"Converted '{epubPath}' to DOCX successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing '{epubPath}': {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}