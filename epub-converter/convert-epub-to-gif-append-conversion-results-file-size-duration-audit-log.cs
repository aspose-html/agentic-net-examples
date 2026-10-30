// Convert EPUB to GIF and append conversion results, including file size and duration, to an audit log.

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string inputPath = "sample.epub";
            string outputPath = "output.gif";
            string logPath = "audit.log";

            // Ensure input file exists (create empty placeholder if missing)
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Prepare conversion options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Measure conversion time
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Perform conversion
            using (System.IO.FileStream epubStream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            stopwatch.Stop();

            // Get output file size
            long fileSize = new System.IO.FileInfo(outputPath).Length;

            // Append audit log entry
            string logEntry = System.String.Format("{0}: Converted '{1}' to '{2}'. Size={3} bytes, Duration={4} ms",
                System.DateTime.Now,
                inputPath,
                outputPath,
                fileSize,
                stopwatch.ElapsedMilliseconds);

            System.IO.File.AppendAllText(logPath, logEntry + System.Environment.NewLine);

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}