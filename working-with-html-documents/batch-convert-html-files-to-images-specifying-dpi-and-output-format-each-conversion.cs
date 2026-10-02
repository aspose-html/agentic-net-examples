// Batch convert HTML files to images, specifying DPI and output format for each conversion.

namespace BatchHtmlToImage
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare output directory
                string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output_images");
                System.IO.Directory.CreateDirectory(outputDir);

                // Input files
                string[] inputs = new string[] { "sample1.html", "sample2.html" };

                // Create sample HTML files if they do not exist
                if (!System.IO.File.Exists(inputs[0]))
                {
                    System.IO.File.WriteAllText(inputs[0], "<html><body><h1>Sample 1</h1></body></html>");
                }
                if (!System.IO.File.Exists(inputs[1]))
                {
                    System.IO.File.WriteAllText(inputs[1], "<html><body><h1>Sample 2</h1></body></html>");
                }

                for (int i = 0; i < inputs.Length; i++)
                {
                    string inputPath = inputs[i];

                    using (var document = new Aspose.Html.HTMLDocument(inputPath, System.IO.Directory.GetCurrentDirectory()))
                    {
                        // Choose output format per file
                        Aspose.Html.Rendering.Image.ImageFormat format = (i == 0) ? Aspose.Html.Rendering.Image.ImageFormat.Jpeg : Aspose.Html.Rendering.Image.ImageFormat.Png;

                        // Configure image options with DPI
                        var options = new Aspose.Html.Saving.ImageSaveOptions(format);
                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;

                        string outputFileName = System.IO.Path.GetFileNameWithoutExtension(inputPath) + (format == Aspose.Html.Rendering.Image.ImageFormat.Jpeg ? ".jpg" : ".png");
                        string outputPath = System.IO.Path.Combine(outputDir, outputFileName);

                        // Convert HTML to image
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}