// Load an MHTML file and convert it to PNG format, extracting embedded images automatically.

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mht";
                string outputPath = "output.png";

                if (!System.IO.File.Exists(inputPath))
                {
                    string htmlContent = "<html><body><h1>Hello, MHTML!</h1></body></html>";
                    System.IO.File.WriteAllText(inputPath, htmlContent);
                }

                using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}