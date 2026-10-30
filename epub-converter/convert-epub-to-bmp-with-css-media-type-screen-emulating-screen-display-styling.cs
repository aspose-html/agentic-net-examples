// Convert EPUB to BMP using ImageSaveOptions.CssMediaType='screen' to emulate screen display styling during rendering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            // Create a placeholder EPUB file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                System.Console.WriteLine("EPUB successfully converted to BMP: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}