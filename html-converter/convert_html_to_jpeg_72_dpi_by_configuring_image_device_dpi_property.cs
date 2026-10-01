// Convert HTML to JPEG with 72 DPI resolution by configuring ImageDevice DPI property accordingly.

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                string outputPath = "output.jpg";

                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                }

                var document = new Aspose.Html.HTMLDocument(htmlPath);
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 72;
                options.VerticalResolution = 72;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}