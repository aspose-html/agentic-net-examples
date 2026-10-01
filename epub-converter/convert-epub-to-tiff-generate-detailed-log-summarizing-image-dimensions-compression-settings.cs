// Convert EPUB to TIFF and generate a detailed log entry summarizing image dimensions and compression settings.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.epub";
                string outputPath = "output.tiff";

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllBytes(inputPath, new byte[0]);
                }

                using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                    {
                        Compression = Aspose.Html.Rendering.Image.Compression.None,
                        UseAntialiasing = true,
                        HorizontalResolution = 300,
                        VerticalResolution = 300,
                        BackgroundColor = System.Drawing.Color.White
                    };

                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(800, 1200),
                        new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }

                System.Text.StringBuilder logBuilder = new System.Text.StringBuilder();
                logBuilder.AppendLine("EPUB to TIFF conversion completed.");
                logBuilder.AppendLine($"Output file: {outputPath}");
                logBuilder.AppendLine("Image settings:");
                logBuilder.AppendLine("  Dimensions: 800x1200");
                logBuilder.AppendLine("  Horizontal Resolution: 300 DPI");
                logBuilder.AppendLine("  Vertical Resolution: 300 DPI");
                logBuilder.AppendLine("  Compression: None");
                logBuilder.AppendLine("  Background Color: White");
                System.Console.WriteLine(logBuilder.ToString());
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}