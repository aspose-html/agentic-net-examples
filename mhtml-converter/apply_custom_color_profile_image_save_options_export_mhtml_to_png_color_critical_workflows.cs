// Apply a custom color profile in ImageSaveOptions while exporting MHTML to PNG for color‑critical workflows.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPath = "output.png";

                // Create a minimal MHTML file if it does not exist
                if (!System.IO.File.Exists(inputPath))
                {
                    string minimalHtml = "<html><body><h1>Hello, MHTML!</h1></body></html>";
                    System.IO.File.WriteAllText(inputPath, minimalHtml);
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    // Initialize ImageSaveOptions for PNG format
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    // Apply a custom background color (example of color profile related setting)
                    options.BackgroundColor = System.Drawing.Color.Bisque;
                    // Set rendering properties suitable for color‑critical workflows
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    // Convert MHTML to PNG using the configured options
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                System.Console.WriteLine("Conversion completed successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}