// Save a single page with HTMLSaveOptions that embed all CSS resources inline for offline viewing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string cssPath = "style.css";
            string outputPath = "output.html";

            // Create a minimal HTML file that references an external CSS file
            System.IO.File.WriteAllText(inputPath,
                "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><h1>Hello World</h1></body></html>");

            // Create a minimal CSS file
            System.IO.File.WriteAllText(cssPath, "h1 { color: red; }");

            // Load the HTML document from the file system
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Configure HTML save options to embed resources (CSS) inline
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 10;

            // Save the document with the configured options
            document.Save(outputPath, options);

            Console.WriteLine("HTML saved with embedded resources to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}