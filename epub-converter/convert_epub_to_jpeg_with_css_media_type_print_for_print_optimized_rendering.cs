// Convert EPUB to JPEG with ImageSaveOptions.CssMediaType set to 'print' for print‑optimized rendering.

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string inputFile = System.IO.Path.Combine(dataDir, "sample.epub");
            string outputDir = "Output";

            System.IO.Directory.CreateDirectory(dataDir);
            System.IO.Directory.CreateDirectory(outputDir);

            if (!System.IO.File.Exists(inputFile))
            {
                System.IO.File.WriteAllBytes(inputFile, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputFile))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.Css.MediaType = Aspose.Html.Rendering.MediaType.Print;
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputDir);
            }

            System.Console.WriteLine("EPUB conversion to JPEG completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}