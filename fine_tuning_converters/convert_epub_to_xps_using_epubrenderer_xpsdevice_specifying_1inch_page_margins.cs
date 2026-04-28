// Convert an EPUB to XPS using EpubRenderer and XpsDevice while specifying 1‑inch page margins.

using System;
using System.IO;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Xps;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string epubPath = "input.epub";
            // Output XPS file path
            string xpsPath = "output.xps";

            // Open the EPUB file as a stream
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                // Configure XPS rendering options with 1‑inch margins
                XpsRenderingOptions renderingOptions = new XpsRenderingOptions();
                renderingOptions.PageSetup.AnyPage = new Page(
                    new Size(
                        Length.FromInches(8.5),   // page width (example)
                        Length.FromInches(11)     // page height (example)
                    ),
                    new Margin(
                        Length.FromInches(1), // top
                        Length.FromInches(1), // right
                        Length.FromInches(1), // bottom
                        Length.FromInches(1)  // left
                    )
                );

                // Create XPS device with the specified options and output path
                using (XpsDevice xpsDevice = new XpsDevice(renderingOptions, xpsPath))
                {
                    // Initialize the EPUB renderer
                    EpubRenderer renderer = new EpubRenderer();

                    // Render the EPUB content to XPS
                    renderer.Render(xpsDevice, epubStream);
                }
            }

            Console.WriteLine("EPUB successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}