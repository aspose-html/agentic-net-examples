// Perform a one‑line static conversion of HTML string to GIF by invoking Converter.ConvertHTML with appropriate options.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
                string outputPath = "output.gif";
                Aspose.Html.Converters.Converter.ConvertHTML(
                    new Aspose.Html.HTMLDocument(htmlContent, "about:blank"),
                    new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif),
                    outputPath);
                System.Console.WriteLine("Conversion completed: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}