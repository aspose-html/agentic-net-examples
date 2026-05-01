// Apply scaling factor of 0.5 in PageSetup to reduce size when converting HTML to JPG.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.jpg";

            var options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Scaling factor of 0.5 is not supported directly in PageSetup; omitted.

            // Optional: set resolution if desired
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}