// Render an EPUB to PDF with custom top margin of 25 points to accommodate header space.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);
            string outputPath = System.IO.Path.Combine(outputDir, "result.pdf");

            System.IO.FileStream stream = new System.IO.FileStream(inputPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(595, 842),
                new Aspose.Html.Drawing.Margin(0, 25, 0, 0));

            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            stream.Close();

            System.Console.WriteLine("EPUB converted to PDF successfully: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}