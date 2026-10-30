// Convert EPUB to TIFF with ImageSaveOptions.CssMediaType configured as 'print' to apply print styles.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.tiff";

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                options.Css.MediaType = Aspose.Html.Rendering.MediaType.Print;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                System.Console.WriteLine("EPUB has been successfully converted to TIFF.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}