// Create a style sheet file, reference it in the HTML head, and verify styles apply after rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "Sample");
            Directory.CreateDirectory(baseDir);
            string cssPath = Path.Combine(baseDir, "style.css");
            string htmlPath = Path.Combine(baseDir, "index.html");
            string outputImagePath = Path.Combine(baseDir, "rendered.png");

            // Create CSS file
            File.WriteAllText(cssPath, "body { background-color: rgb(229, 243, 253); }");

            // Create HTML file that references the CSS
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8' />
    <title>Style Test</title>
    <link rel='stylesheet' href='style.css' />
</head>
<body>
    <h1>Style Sheet Verification</h1>
    <p>If the background is light blue, the style was applied.</p>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document (relative links will resolve using the file's directory)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Prepare image save options
            Aspose.Html.Saving.ImageSaveOptions imageOptions = new Aspose.Html.Saving.ImageSaveOptions();
            imageOptions.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;

            // Render HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, imageOptions, outputImagePath);

            Console.WriteLine("Rendering completed. Output saved to: " + outputImagePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}