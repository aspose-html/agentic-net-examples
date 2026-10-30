// Convert an EPUB to XPS using EpubRenderer and XpsDevice while specifying 1‑inch page margins.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.xps";

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                // Configure XPS save options with 1‑inch margins
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.5),
                        Aspose.Html.Drawing.Length.FromInches(11)),
                    new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromInches(1),
                        Aspose.Html.Drawing.Length.FromInches(1),
                        Aspose.Html.Drawing.Length.FromInches(1),
                        Aspose.Html.Drawing.Length.FromInches(1)));

                options.PageSetup.AnyPage = page;

                // Create XPS device
                Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(options, outputPath);

                // Render EPUB to XPS
                Aspose.Html.Rendering.EpubRenderer renderer = new Aspose.Html.Rendering.EpubRenderer();
                renderer.Render(device, stream);
            }

            Console.WriteLine("EPUB successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}