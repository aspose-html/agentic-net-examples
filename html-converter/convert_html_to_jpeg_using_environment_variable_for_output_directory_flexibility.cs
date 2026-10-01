// Convert HTML to JPEG using an environment variable to define the output directory for flexibility.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input folder (hardcoded for this example)
            string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input");
            System.IO.Directory.CreateDirectory(inputFolder);

            // Create a sample HTML file if none exist
            string sampleHtmlPath = System.IO.Path.Combine(inputFolder, "sample.html");
            if (!System.IO.File.Exists(sampleHtmlPath))
            {
                string sampleContent = "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>";
                System.IO.File.WriteAllText(sampleHtmlPath, sampleContent);
            }

            // Get output directory from environment variable or use default
            string outputFolderEnv = System.Environment.GetEnvironmentVariable("OUTPUT_DIR");
            string outputFolder = string.IsNullOrEmpty(outputFolderEnv)
                ? System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output")
                : outputFolderEnv;
            System.IO.Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}