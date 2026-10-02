// Transform an EPUB file into DOCX using EpubRenderer and DocDevice with custom margin settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output DOCX file paths
            string sourcePath = "sample.epub";
            string outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);
            string outputPath = System.IO.Path.Combine(outputDir, "result.docx");

            // Open the EPUB file as a stream
            using (System.IO.FileStream stream = System.IO.File.OpenRead(sourcePath))
            {
                // Create the EPUB renderer
                using (Aspose.Html.Rendering.EpubRenderer renderer = new Aspose.Html.Rendering.EpubRenderer())
                {
                    // Configure DOC rendering options with custom page size and margins
                    Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(612, 792), // 8.5 x 11 inches in points
                        new Aspose.Html.Drawing.Margin(72, 72, 72, 72) // 1 inch margins (top, right, bottom, left)
                    );
                    options.PageSetup.AnyPage = page;

                    // Create the DOC device with the specified options and output path
                    using (Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath))
                    {
                        // Render the EPUB content to DOCX
                        renderer.Render(device, stream);
                    }
                }
            }

            System.Console.WriteLine("EPUB successfully converted to DOCX at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}