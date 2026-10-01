// Convert HTML strings directly to TIFF images using one‑line static conversion with custom options.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.BackgroundColor = System.Drawing.Color.White;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.tiff");
            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}