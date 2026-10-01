// Generate a thumbnail PNG from HTML by setting reduced page dimensions in ImageSaveOptions before conversion.

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "thumbnail.png";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(200, 200));
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            var document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}