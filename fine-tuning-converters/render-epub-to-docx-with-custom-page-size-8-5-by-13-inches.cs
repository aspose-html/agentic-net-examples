// Render an EPUB to DOCX while setting DocRenderingOptions.PageSize to custom 8.5 by 13 inches.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(epubPath))
            {
                // Create a placeholder empty EPUB file
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.5),
                        Aspose.Html.Drawing.Length.FromInches(13)));

                string savePath = Path.Combine(outputDir, "output.docx");
                using (var device = new Aspose.Html.Rendering.Doc.DocDevice(options, savePath))
                {
                    using (var renderer = new Aspose.Html.Rendering.EpubRenderer())
                    {
                        renderer.Render(device, stream);
                    }
                }

                Console.WriteLine("EPUB rendered to DOCX successfully: " + savePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}