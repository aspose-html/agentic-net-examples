// Convert HTML to TIFF using a temporary file for intermediate storage and delete the file after conversion.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, TIFF!</h1></body></html>";
            string tempPath = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllText(tempPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;

            string outputPath = "output.tiff";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.IO.File.Delete(tempPath);
            System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}