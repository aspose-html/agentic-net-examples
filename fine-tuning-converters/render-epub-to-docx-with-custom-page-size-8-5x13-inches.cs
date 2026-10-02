// Render an EPUB to DOCX while setting DocRenderingOptions.PageSize to custom 8.5 by 13 inches.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.docx";

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.5),
                        Aspose.Html.Drawing.Length.FromInches(13)));

                using (var device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath))
                {
                    var renderer = new Aspose.Html.Rendering.EpubRenderer();
                    renderer.Render(device, stream);
                }
            }

            Console.WriteLine("EPUB successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}