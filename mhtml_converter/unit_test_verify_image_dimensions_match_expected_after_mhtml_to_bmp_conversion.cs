// Develop a unit test that verifies the image dimensions match expected values after MHTML to BMP conversion.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

namespace MhtmlToBmpDimensionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string mhtmlPath = "sample.mhtml";
                string bmpPath = "result.bmp";

                // Expected dimensions (replace with actual expected values)
                int expectedWidth = 800;
                int expectedHeight = 600;

                // Open the source MHTML file as a stream
                Stream stream = File.OpenRead(mhtmlPath);

                // Configure image save options for BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Convert MHTML to BMP
                Converter.ConvertMHTML(stream, options, bmpPath);

                // Load the generated BMP image to verify dimensions
                using (Image bmpImage = Image.FromFile(bmpPath))
                {
                    int actualWidth = bmpImage.Width;
                    int actualHeight = bmpImage.Height;

                    if (actualWidth == expectedWidth && actualHeight == expectedHeight)
                    {
                        Console.WriteLine("Test Passed: Image dimensions match expected values.");
                    }
                    else
                    {
                        Console.WriteLine($"Test Failed: Expected {expectedWidth}x{expectedHeight}, but got {actualWidth}x{actualHeight}.");
                    }
                }

                // Clean up resources
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}