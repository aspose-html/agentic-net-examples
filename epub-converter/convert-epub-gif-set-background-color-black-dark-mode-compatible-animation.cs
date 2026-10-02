// Convert EPUB to GIF and set ImageSaveOptions.BackgroundColor to black for dark‑mode compatible animation.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            if (!System.IO.File.Exists(inputPath))
            {
                System.Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.BackgroundColor = System.Drawing.Color.Black;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine($"EPUB converted to GIF successfully: {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}