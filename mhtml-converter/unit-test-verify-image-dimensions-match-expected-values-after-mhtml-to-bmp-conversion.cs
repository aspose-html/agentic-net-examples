// Develop a unit test that verifies the image dimensions match expected values after MHTML to BMP conversion.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPath = "output.bmp";

                // Create a minimal MHTML (HTML) file if it does not exist
                if (!System.IO.File.Exists(inputPath))
                {
                    string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
                    System.IO.File.WriteAllText(inputPath, htmlContent);
                }

                // Open the source MHTML file
                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    // Configure image save options for BMP format
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                    options.UseAntialiasing = false;
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(
                            Aspose.Html.Drawing.Length.FromPixels(200),
                            Aspose.Html.Drawing.Length.FromPixels(100)));

                    // Convert MHTML to BMP
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                // Verify the dimensions of the generated BMP image
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(outputPath))
                {
                    int expectedWidth = 200;
                    int expectedHeight = 100;

                    if (image.Width == expectedWidth && image.Height == expectedHeight)
                    {
                        System.Console.WriteLine("Test passed: Image dimensions match expected values.");
                    }
                    else
                    {
                        System.Console.WriteLine($"Test failed: Expected {expectedWidth}x{expectedHeight}, but got {image.Width}x{image.Height}.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}