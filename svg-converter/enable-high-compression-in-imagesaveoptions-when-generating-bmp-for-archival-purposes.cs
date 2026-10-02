// Enable high compression in ImageSaveOptions when generating BMP for archival purposes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgCode = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
                                  <rect width='200' height='200' fill='red'/>
                               </svg>";

            // Output file name
            string savePath = "archival_image.bmp";

            // Configure image save options for BMP with high resolution
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 400;
            options.VerticalResolution = 400;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            // Note: Compression property is not available in this version of the API.

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, ".", options, savePath);

            Console.WriteLine($"BMP image saved to: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}