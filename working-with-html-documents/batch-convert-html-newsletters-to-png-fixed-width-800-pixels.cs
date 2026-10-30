// Batch convert HTML newsletters, converting each to PNG with a fixed width of 800 pixels.

namespace AsposeHtmlBatchConvert
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input and output directories
                string inputDir = "input";
                string outputDir = "output";

                // Ensure directories exist
                System.IO.Directory.CreateDirectory(inputDir);
                System.IO.Directory.CreateDirectory(outputDir);

                // Create sample HTML files if none exist
                if (System.IO.Directory.GetFiles(inputDir, "*.html").Length == 0)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        string samplePath = System.IO.Path.Combine(inputDir, $"newsletter{i}.html");
                        string htmlContent = $"<html><body><h1>Newsletter {i}</h1><p>This is sample content for newsletter {i}.</p></body></html>";
                        System.IO.File.WriteAllText(samplePath, htmlContent);
                    }
                }

                // Get all HTML files
                string[] htmlFiles = System.IO.Directory.GetFiles(inputDir, "*.html");

                foreach (string htmlPath in htmlFiles)
                {
                    // Load document
                    var document = new Aspose.Html.HTMLDocument(htmlPath);

                    // Configure image save options
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    var page = new Aspose.Html.Drawing.Page();
                    page.Size = new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(800),
                        Aspose.Html.Drawing.Length.FromPixels(0));
                    options.PageSetup.AnyPage = page;

                    // Determine output path
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(htmlPath);
                    string outputPath = System.IO.Path.Combine(outputDir, fileName + ".png");

                    // Convert HTML to PNG
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }

                System.Console.WriteLine("Batch conversion completed.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}