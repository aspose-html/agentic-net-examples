// Convert pixel dimensions to inches and use them to calculate physical page dimensions for printing.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double widthPixels = 800;
            double heightPixels = 600;

            // Pixels per inch (standard)
            const double ppi = 96.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Output inches
            Console.WriteLine($"Width: {widthInches} inches");
            Console.WriteLine($"Height: {heightInches} inches");

            // Convert to millimeters for page setup
            double widthMillimeters = widthPixels / 96.0 * 25.4;
            double heightMillimeters = heightPixels / 96.0 * 25.4;

            // Prepare image save options with page size based on millimeters
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.PageSetup.AnyPage = new Page(
                new Size(
                    Length.FromMillimeters(widthMillimeters),
                    Length.FromMillimeters(heightMillimeters)));

            // Convert an MHTML file to JPEG using the calculated page size
            string sourcePath = "input.mhtml";
            string outputPath = "output.jpg";
            Converter.ConvertMHTML(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}