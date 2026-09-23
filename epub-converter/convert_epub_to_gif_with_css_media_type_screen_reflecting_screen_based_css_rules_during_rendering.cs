// Convert EPUB to GIF using ImageSaveOptions.CssMediaType='screen' to reflect screen‑based CSS rules during rendering.

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "input.epub";
            string outputPath = "output.gif";

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

            stream.Close();

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}