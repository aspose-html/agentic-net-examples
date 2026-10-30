// Convert EPUB to JPEG while specifying a custom page size in ImageSaveOptions for precise layout.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.jpg";

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            System.Console.WriteLine("EPUB conversion to JPEG completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}