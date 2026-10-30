// Convert EPUB to TIFF using ImageSaveOptions.Margins to ensure consistent spacing around rendered pages.

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.tiff";

            // Create a placeholder EPUB file if it does not exist (for demonstration purposes)
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
            {
                Compression = Aspose.Html.Rendering.Image.Compression.None,
                UseAntialiasing = true,
                HorizontalResolution = 300,
                VerticalResolution = 300,
                BackgroundColor = System.Drawing.Color.White
            };

            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(1200, 1600),
                new Aspose.Html.Drawing.Margin(20, 20, 20, 20));

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}