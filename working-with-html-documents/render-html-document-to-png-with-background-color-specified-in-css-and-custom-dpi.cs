// Render an HTML document to PNG with a background color specified in CSS and custom DPI.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><style>body { background-color: bisque; }</style></head><body><h1>Hello, Aspose!</h1></body></html>";
            string baseUri = new System.Uri(System.IO.Path.GetFullPath("")).AbsoluteUri;
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
            System.Console.WriteLine("HTML rendered to PNG successfully: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}