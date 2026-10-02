// Configure ImageSaveOptions to set background color when converting MHTML to BMP format.

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mht";
                string outputPath = "output.bmp";

                // Create a minimal MHTML file (simple HTML content)
                System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello, MHTML!</h1></body></html>");

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                    options.BackgroundColor = System.Drawing.Color.Beige;
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