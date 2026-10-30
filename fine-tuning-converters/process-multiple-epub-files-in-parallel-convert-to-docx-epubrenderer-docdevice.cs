// Process multiple EPUB files in parallel, converting each to DOCX using EpubRenderer and DocDevice.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputDocs";

            if (!Directory.Exists(inputDir))
                Directory.CreateDirectory(inputDir);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");

            Parallel.ForEach(epubFiles, epubPath =>
            {
                try
                {
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".docx");

                    using (FileStream stream = File.OpenRead(epubPath))
                    using (Aspose.Html.Rendering.EpubRenderer renderer = new Aspose.Html.Rendering.EpubRenderer())
                    {
                        Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

                        using (Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath))
                        {
                            renderer.Render(device, stream);
                        }
                    }

                    Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
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