// Render an EPUB to DOCX while setting DocRenderingOptions.PageSize to custom 8.5 by 13 inches.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(dataDir, "output.docx");

            if (!File.Exists(sourcePath))
            {
                File.WriteAllBytes(sourcePath, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(sourcePath))
            {
                Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

                Aspose.Html.Drawing.Length width = Aspose.Html.Drawing.Length.FromInches(8.5);
                Aspose.Html.Drawing.Length height = Aspose.Html.Drawing.Length.FromInches(13);
                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(width, height);
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize);
                options.PageSetup.AnyPage = page;

                using (Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath))
                {
                    Aspose.Html.Rendering.EpubRenderer renderer = new Aspose.Html.Rendering.EpubRenderer();
                    renderer.Render(device, stream);
                }
            }

            Console.WriteLine("EPUB has been successfully rendered to DOCX at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}