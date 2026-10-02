// Convert an SVG to BMP while specifying a DPI of 300 in ImageSaveOptions.

class Program
{
    static void Main()
    {
        try
        {
            string code = "<svg width=\"100\" height=\"100\" xmlns=\"http://www.w3.org/2000/svg\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
            string savePath = "output.bmp";
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            Aspose.Html.Converters.Converter.ConvertSVG(code, ".", options, savePath);
            System.Console.WriteLine("SVG converted to BMP successfully: " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}