// Configure ImageSaveOptions to enable lossless compression for PNG output when preserving image fidelity is critical.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPath = "output.png";

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath, "From: <test@example.com>\nSubject: Test\n\n<html><body><h1>Sample</h1></body></html>");
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                System.Console.WriteLine("Conversion completed successfully. Output saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}