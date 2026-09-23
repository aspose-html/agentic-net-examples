// Convert EPUB to GIF while recording overall conversion statistics and outputting them to the console for monitoring.

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
                using (var fs = System.IO.File.Create(inputPath)) { }
                System.Console.WriteLine($"Created placeholder input file: {inputPath}");
            }

            using (var stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

                stopwatch.Stop();

                System.Console.WriteLine("Conversion completed.");
                System.Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");

                if (System.IO.File.Exists(outputPath))
                {
                    var fileInfo = new System.IO.FileInfo(outputPath);
                    System.Console.WriteLine($"Output file size: {fileInfo.Length} bytes");
                }
                else
                {
                    System.Console.WriteLine("Output file was not created.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}