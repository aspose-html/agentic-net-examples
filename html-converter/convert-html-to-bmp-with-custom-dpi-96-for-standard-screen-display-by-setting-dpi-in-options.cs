// Convert HTML to BMP with custom DPI of 96 for standard screen display by setting DPI in options.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                string outputPath = "output.bmp";

                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, BMP!</h1></body></html>");
                }

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}