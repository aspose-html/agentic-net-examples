// Benchmark conversion time for MHTML to GIF using different ImageSaveOptions quality levels.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPathLow = "output_low.gif";
                string outputPathHigh = "output_high.gif";

                if (!System.IO.File.Exists(inputPath))
                {
                    string simpleHtml = "<html><body><h1>Hello World</h1></body></html>";
                    System.IO.File.WriteAllText(inputPath, simpleHtml);
                }

                var optionsLow = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
                using (var stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, optionsLow, outputPathLow);
                }
                stopwatch.Stop();
                long elapsedLow = stopwatch.ElapsedMilliseconds;

                var optionsHigh = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                optionsHigh.HorizontalResolution = 300;
                optionsHigh.VerticalResolution = 300;

                stopwatch.Restart();
                using (var stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, optionsHigh, outputPathHigh);
                }
                stopwatch.Stop();
                long elapsedHigh = stopwatch.ElapsedMilliseconds;

                System.Console.WriteLine($"Conversion with default resolution took {elapsedLow} ms, output: {outputPathLow}");
                System.Console.WriteLine($"Conversion with 300 DPI resolution took {elapsedHigh} ms, output: {outputPathHigh}");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}