// Convert HTML to PNG after injecting custom JavaScript that modifies the DOM for dynamic content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><script>document.body.innerHTML += '<p>Dynamic content added by JavaScript.</p>';</script></head><body><h1>Static Header</h1></body></html>";
            string outputPath = "output.png";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, "", options, outputPath);

            Console.WriteLine("HTML has been converted to PNG successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}