// Batch convert HTML files to images, specifying DPI and output format for each conversion.

namespace BatchHtmlToImage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Prepare output directory
                string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output_images");
                System.IO.Directory.CreateDirectory(outputDir);

                // Input files and desired output formats
                string[] inputs = new string[] { "sample1.html", "sample2.html" };
                Aspose.Html.Rendering.Image.ImageFormat[] formats = new Aspose.Html.Rendering.Image.ImageFormat[]
                {
                    Aspose.Html.Rendering.Image.ImageFormat.Jpeg,
                    Aspose.Html.Rendering.Image.ImageFormat.Png
                };

                // Create minimal sample HTML files if they do not exist
                for (int i = 0; i < inputs.Length; i++)
                {
                    if (!System.IO.File.Exists(inputs[i]))
                    {
                        string htmlContent = "<html><body><h1>Sample " + (i + 1) + "</h1></body></html>";
                        System.IO.File.WriteAllText(inputs[i], htmlContent);
                    }
                }

                // Batch conversion
                for (int i = 0; i < inputs.Length; i++)
                {
                    string inputPath = inputs[i];
                    using (var document = new Aspose.Html.HTMLDocument(inputPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(formats[i]);
                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;

                        string extension = formats[i] == Aspose.Html.Rendering.Image.ImageFormat.Jpeg ? ".jpg" : ".png";
                        string outputPath = System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(inputPath) + extension);

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