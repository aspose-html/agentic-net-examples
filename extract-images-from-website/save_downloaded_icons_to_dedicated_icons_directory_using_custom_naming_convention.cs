// Save downloaded icons to a dedicated icons directory using a custom naming convention.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define the icons output directory
            string iconsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "icons");
            Directory.CreateDirectory(iconsDirectory);

            // Sample SVG icon contents
            List<string> svgContents = new List<string>
            {
                @"<svg xmlns='http://www.w3.org/2000/svg' width='64' height='64'><circle cx='32' cy='32' r='30' fill='red' /></svg>",
                @"<svg xmlns='http://www.w3.org/2000/svg' width='64' height='64'><rect width='60' height='60' x='2' y='2' fill='green' /></svg>"
            };

            for (int i = 0; i < svgContents.Count; i++)
            {
                // Create a temporary SVG file
                string tempSvgPath = Path.Combine(Path.GetTempPath(), $"icon_{i}.svg");
                File.WriteAllText(tempSvgPath, svgContents[i]);

                // Define output PNG path with custom naming convention
                string outputPngPath = Path.Combine(iconsDirectory, $"custom_icon_{i + 1}.png");

                // Set image save options
                ImageSaveOptions options = new ImageSaveOptions();

                // Convert SVG to PNG
                Aspose.Html.Converters.Converter.ConvertSVG(tempSvgPath, "", options, outputPngPath);

                // Clean up temporary SVG file
                File.Delete(tempSvgPath);
            }

            Console.WriteLine("Icons have been saved to: " + iconsDirectory);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}