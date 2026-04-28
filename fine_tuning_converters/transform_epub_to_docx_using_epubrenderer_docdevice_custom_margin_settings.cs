// Transform an EPUB file into DOCX using EpubRenderer and DocDevice with custom margin settings.

using System;
using System.IO;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "DataDir";
            string outputDir = "OutputDir";

            using (FileStream stream = File.OpenRead(Path.Combine(dataDir, "input.epub")))
            using (EpubRenderer renderer = new EpubRenderer())
            {
                string savePath = Path.Combine(outputDir, "output.docx");

                DocRenderingOptions options = new DocRenderingOptions();
                options.PageSetup.AnyPage = new Page(
                    new Size(800, 600),
                    new Margin(50, 50, 50, 50)); // top, right, bottom, left margins

                using (DocDevice device = new DocDevice(options, savePath))
                {
                    renderer.Render(device, stream);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}