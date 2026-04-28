// Process multiple EPUB files in parallel, converting each to DOCX using EpubRenderer and DocDevice.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Directory containing EPUB files
            string inputDir = "InputEpubs";
            // Directory where DOCX files will be saved
            string outputDir = "OutputDocx";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all EPUB files in the input directory
            var epubFiles = Directory.GetFiles(inputDir, "*.epub");

            // Process each EPUB file in parallel
            Parallel.ForEach(epubFiles, epubPath =>
            {
                // Determine output DOCX file path
                string fileName = Path.GetFileNameWithoutExtension(epubPath);
                string outputPath = Path.Combine(outputDir, fileName + ".docx");

                // Open the EPUB file as a read‑only stream
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    // Create an EPub renderer
                    using (EpubRenderer renderer = new EpubRenderer())
                    {
                        // Configure DOC rendering options (optional page size)
                        DocRenderingOptions options = new DocRenderingOptions();
                        options.PageSetup.AnyPage = new Page(new Size(800, 400));

                        // Create a DOC device that writes to the output path
                        using (DocDevice device = new DocDevice(options, outputPath))
                        {
                            // Render the EPUB stream to DOCX using the device
                            renderer.Render(device, stream);
                        }
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}