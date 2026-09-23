// Create a command‑line utility that accepts EPUB input path and GIF output path as arguments.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "sample.epub";
            string outputPath = args.Length > 1 ? args[1] : "output.gif";

            if (!System.IO.File.Exists(inputPath))
            {
                System.Console.WriteLine($"Input EPUB file not found: {inputPath}");
                return;
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine($"Conversion completed. GIF saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}