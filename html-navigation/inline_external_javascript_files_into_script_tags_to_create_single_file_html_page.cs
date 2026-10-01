// Inline external JavaScript files into script tags to create a single‑file HTML page.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.html";
                string outputPath = "single_file.html";

                // Create a minimal sample HTML and external JS file if they do not exist
                if (!System.IO.File.Exists(inputPath))
                {
                    string htmlContent = "<!DOCTYPE html><html><head><script src=\"script.js\"></script></head><body><h1>Hello</h1></body></html>";
                    System.IO.File.WriteAllText(inputPath, htmlContent);
                    string jsContent = "console.log('Hello from external script');";
                    System.IO.File.WriteAllText("script.js", jsContent);
                }

                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

                // Configure save options to embed external JavaScript
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

                // Save the single‑file HTML
                document.Save(outputPath, options);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}