// Write unit tests verifying that MHTML to PNG conversion produces an image with expected dimensions.

using System;
using System.IO;
using System.Drawing;

namespace AsposeHtmlMhtmlToPngTest
{
    class Program
    {
        static void Main()
        {
            try
            {
                Tests.RunAll();
                Console.WriteLine("All tests passed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test failed: " + ex.Message);
            }
        }
    }

    public static class Tests
    {
        public static void RunAll()
        {
            TestMhtmlToPngDimensions();
        }

        public static void TestMhtmlToPngDimensions()
        {
            // Prepare input MHTML file (simple HTML content for demonstration)
            string inputPath = "sample.mhtml";
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Define output PNG path
            string outputPath = "output.png";

            // Convert MHTML to PNG with specific page size
            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(800),
                        Aspose.Html.Drawing.Length.FromPixels(600)));

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            // Verify the dimensions of the generated PNG
            using (Image img = Image.FromFile(outputPath))
            {
                int expectedWidth = 800;
                int expectedHeight = 600;

                if (img.Width != expectedWidth)
                {
                    throw new InvalidOperationException($"Image width {img.Width} does not match expected value {expectedWidth}.");
                }

                if (img.Height != expectedHeight)
                {
                    throw new InvalidOperationException($"Image height {img.Height} does not match expected value {expectedHeight}.");
                }
            }
        }
    }
}