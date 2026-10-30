// Transform an EPUB file into DOCX using EpubRenderer and DocDevice with custom margin settings.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputPath = "result.docx";

            if (!System.IO.File.Exists(sourcePath))
            {
                using (var fs = System.IO.File.Create(sourcePath)) { }
            }

            using (System.IO.FileStream stream = System.IO.File.OpenRead(sourcePath))
            {
                using (Aspose.Html.Rendering.EpubRenderer renderer = new Aspose.Html.Rendering.EpubRenderer())
                {
                    Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(800, 1000),
                        new Aspose.Html.Drawing.Margin(72, 72, 72, 72));

                    using (Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath))
                    {
                        renderer.Render(device, stream);
                    }
                }
            }

            System.Console.WriteLine("EPUB converted to DOCX successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}