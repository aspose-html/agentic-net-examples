// Transform an EPUB file into DOCX using EpubRenderer and DocDevice with custom margin settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.epub";
            string outputPath = "output.docx";

            if (!File.Exists(sourcePath))
            {
                // Create an empty placeholder EPUB file if it does not exist.
                File.WriteAllBytes(sourcePath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(sourcePath))
            {
                // Configure DOC rendering options with custom page size and margins.
                Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.5),
                        Aspose.Html.Drawing.Length.FromInches(11)),
                    new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromInches(1),
                        Aspose.Html.Drawing.Length.FromInches(1),
                        Aspose.Html.Drawing.Length.FromInches(1),
                        Aspose.Html.Drawing.Length.FromInches(1)));

                using (Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath))
                using (Aspose.Html.Rendering.EpubRenderer renderer = new Aspose.Html.Rendering.EpubRenderer())
                {
                    renderer.Render(device, stream);
                }
            }

            Console.WriteLine("EPUB has been successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}