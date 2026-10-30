// Develop a unit test that verifies the image dimensions match expected values after MHTML to BMP conversion.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input MHTML file (minimal content)
            string inputPath = "sample.mht";
            string htmlContent = @"<html><body><h1>Test</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Output BMP file path
            string outputPath = "output.bmp";

            // Open the source MHTML stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for BMP with explicit page size
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(200),
                        Aspose.Html.Drawing.Length.FromPixels(100)
                    )
                );
                options.UseAntialiasing = false;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                // Convert MHTML to BMP
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            // Verify the dimensions of the generated BMP
            using (Image bmp = Image.FromFile(outputPath))
            {
                int expectedWidth = 200;
                int expectedHeight = 100;

                if (bmp.Width == expectedWidth && bmp.Height == expectedHeight)
                {
                    Console.WriteLine("Success: Image dimensions match expected values.");
                }
                else
                {
                    Console.WriteLine($"Failure: Expected {expectedWidth}x{expectedHeight}, but got {bmp.Width}x{bmp.Height}.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}