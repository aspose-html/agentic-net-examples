// Set ImageSaveOptions to preserve EXIF metadata when converting MHTML to JPEG images.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            string outputPath = "output.jpg";

            using (System.IO.Stream stream = System.IO.File.OpenRead(sourcePath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}