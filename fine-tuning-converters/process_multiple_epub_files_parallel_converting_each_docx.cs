// Process multiple EPUB files in parallel, converting each to DOCX using EpubRenderer and DocDevice.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input EPUB files
            string[] epubFiles = new string[]
            {
                "input1.epub",
                "input2.epub"
            };

            // Ensure output directory exists
            string outputDir = "output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Process files in parallel
            Parallel.ForEach(epubFiles, epubPath =>
            {
                try
                {
                    // Open EPUB file stream
                    using (FileStream epubStream = File.OpenRead(epubPath))
                    {
                        // Prepare output DOCX path
                        string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".docx");

                        // Create rendering options for DOCX
                        var docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

                        // Create DOCX device
                        using (var docDevice = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputPath))
                        {
                            // Create EPUB renderer
                            using (var epubRenderer = new Aspose.Html.Rendering.EpubRenderer())
                            {
                                // Render EPUB to DOCX
                                epubRenderer.Render(docDevice, epubStream);
                            }
                        }
                    }

                    Console.WriteLine($"Successfully converted '{epubPath}' to DOCX.");
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