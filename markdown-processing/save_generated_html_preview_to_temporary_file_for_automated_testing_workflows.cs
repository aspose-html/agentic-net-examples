// Save the generated HTML preview to a temporary file for automated testing workflows.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create a temporary file path for the preview
            string outputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "preview.html");

            // Configure security settings
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load HTML document from the string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, config);

            // Set save options to embed JavaScript resources
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

            // Save the preview to the temporary file
            document.Save(outputPath, options);

            Console.WriteLine($"HTML preview saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}