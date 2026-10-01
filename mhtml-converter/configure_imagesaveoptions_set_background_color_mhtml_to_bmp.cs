// Configure ImageSaveOptions to set background color when converting MHTML to BMP format.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.mhtml";
                string outputPath = "output.bmp";

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath, "<html><body><p>Hello World</p></body></html>");
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                    options.BackgroundColor = System.Drawing.Color.Beige;
                    // options.UseAntialiasing = false;
                    // options.HorizontalResolution = 96;
                    // options.VerticalResolution = 96;

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