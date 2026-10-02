// Configure ImageSaveOptions to set background transparency for PNG output when source MHTML contains transparent elements.

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
                    string htmlContent = "<html><body><div style='width:100px;height:100px;background:rgba(255,0,0,0.5);'></div></body></html>";
                    System.IO.File.WriteAllText(inputPath, htmlContent);
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    options.BackgroundColor = System.Drawing.Color.Transparent;
                    options.UseAntialiasing = true;

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