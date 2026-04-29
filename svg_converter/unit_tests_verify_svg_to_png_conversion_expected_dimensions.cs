// Write unit tests to verify that SVG to PNG conversion produces files of expected dimensions.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare test SVG with known dimensions
            string svgPath = "test.svg";
            string pngPath = "test.png";
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='100'></svg>";
            File.WriteAllText(svgPath, svgContent);

            // Create default image save options
            ImageSaveOptions options = new ImageSaveOptions();

            // Convert SVG to PNG using Aspose.HTML
            Converter.ConvertSVG(svgPath, options, pngPath);

            // Load the resulting PNG and verify its dimensions
            using (Image img = Image.FromFile(pngPath))
            {
                if (img.Width == 200 && img.Height == 100)
                {
                    Console.WriteLine("Test passed: PNG dimensions match expected size 200x100.");
                }
                else
                {
                    Console.WriteLine($"Test failed: PNG dimensions are {img.Width}x{img.Height}, expected 200x100.");
                }
            }

            // Clean up test files
            File.Delete(svgPath);
            File.Delete(pngPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}