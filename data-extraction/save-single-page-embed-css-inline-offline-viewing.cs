// Save a single page with HTMLSaveOptions that embed all CSS resources inline for offline viewing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "SampleData");
            Directory.CreateDirectory(baseDir);
            string htmlPath = Path.Combine(baseDir, "sample.html");
            string cssPath = Path.Combine(baseDir, "style.css");
            string outputPath = Path.Combine(baseDir, "output.html");

            File.WriteAllText(cssPath, "body { background-color: #f0f0f0; } h1 { color: blue; }");
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"style.css\"></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;

            document.Save(outputPath, options);

            Console.WriteLine("Saved HTML to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}