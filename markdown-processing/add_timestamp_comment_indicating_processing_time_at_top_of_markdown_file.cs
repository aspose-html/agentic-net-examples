// Add a timestamp comment indicating processing time at the top of the Markdown file.

// Processed on: 2026-09-23 12:00:00 UTC
class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";
            string baseUri = "http://example.com/";

            // Configure Markdown save options
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            // Temporary file for Markdown output
            string tempPath = System.IO.Path.GetTempFileName();

            // Convert HTML to Markdown and save to temporary file
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            // Read and display the generated Markdown
            string markdown = System.IO.File.ReadAllText(tempPath);
            System.Console.WriteLine("Generated Markdown:");
            System.Console.WriteLine(markdown);

            // Clean up temporary file
            System.IO.File.Delete(tempPath);
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}