// Create a style sheet file, reference it in the HTML head, and verify styles apply after rendering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string currentDir = System.IO.Path.GetFullPath(System.IO.Directory.GetCurrentDirectory());
            string cssPath = System.IO.Path.Combine(currentDir, "styles.css");
            string htmlPath = System.IO.Path.Combine(currentDir, "sample.html");
            string outputPath = System.IO.Path.Combine(currentDir, "output.png");

            // Create CSS file
            string cssContent = "body { background-color: rgb(229, 243, 253); }";
            System.IO.File.WriteAllText(cssPath, cssContent);

            // Create HTML file that references the CSS file
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"styles.css\"></head><body><p>Hello, Aspose.HTML!</p></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Render HTML to an image to verify that the stylesheet is applied
            var imageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertHTML(
                new Aspose.Html.Url(htmlPath),
                null,
                imageOptions,
                outputPath);

            System.Console.WriteLine("Rendering completed. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}