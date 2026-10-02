// Perform a one‑line static conversion of HTML string to PNG by calling Converter.ConvertHTML with ImageSaveOptions.

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><h1>Hello, World!</h1></body></html>";
                string baseUri = "about:blank";
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                string outputPath = "output.png";
                Aspose.Html.Converters.Converter.ConvertHTML(html, baseUri, options, outputPath);
                System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}