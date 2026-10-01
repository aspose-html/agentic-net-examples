// Convert an EPUB file to PDF with custom page size and margins.

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

            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(800),
                        Aspose.Html.Drawing.Length.FromPixels(1000)),
                    new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromPixels(50),
                        Aspose.Html.Drawing.Length.FromPixels(50),
                        Aspose.Html.Drawing.Length.FromPixels(50),
                        Aspose.Html.Drawing.Length.FromPixels(50))
                );

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("EPUB converted to PDF successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}