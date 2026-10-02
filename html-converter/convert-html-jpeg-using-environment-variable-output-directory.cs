// Convert HTML to JPEG using an environment variable to define the output directory for flexibility.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Prepare input folder and sample HTML file
                string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input");
                System.IO.Directory.CreateDirectory(inputFolder);
                string sampleHtmlPath = System.IO.Path.Combine(inputFolder, "sample.html");
                if (!System.IO.File.Exists(sampleHtmlPath))
                {
                    string sampleHtmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                    System.IO.File.WriteAllText(sampleHtmlPath, sampleHtmlContent);
                }

                // Determine output directory from environment variable or fallback
                string outputDirEnv = System.Environment.GetEnvironmentVariable("HTML_OUTPUT_DIR");
                string outputFolder = string.IsNullOrEmpty(outputDirEnv)
                    ? System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output")
                    : outputDirEnv;
                System.IO.Directory.CreateDirectory(outputFolder);

                // Convert each HTML file to JPEG
                foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    }
                }

                System.Console.WriteLine("Conversion completed. Images saved to: " + outputFolder);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}