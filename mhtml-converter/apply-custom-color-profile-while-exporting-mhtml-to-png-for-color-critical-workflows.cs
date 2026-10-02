// Apply a custom color profile in ImageSaveOptions while exporting MHTML to PNG for color‑critical workflows.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.mhtml";
                string outputPath = "output.png";

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.Bisque;

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                System.Console.WriteLine("MHTML has been successfully converted to PNG.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}