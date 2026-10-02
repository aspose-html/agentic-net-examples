// Batch convert HTML newsletters, converting each to PNG with a fixed width of 800 pixels.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML files
            string[] htmlFiles = new string[] { "newsletter1.html", "newsletter2.html" };

            // Ensure sample HTML files exist
            foreach (string path in htmlFiles)
            {
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.WriteAllText(path,
                        "<html><body><h1>Sample Newsletter</h1><p>This is a sample.</p></body></html>");
                }
            }

            // Prepare output directory
            string outputDir = "output";
            if (!System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);

            // Configure image save options for PNG with fixed width 800px
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page
            {
                Size = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromPixels(800),
                    Aspose.Html.Drawing.Length.FromPixels(0))
            };
            options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToWidestContentWidth;

            // Convert each HTML file to PNG
            foreach (string htmlPath in htmlFiles)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(htmlPath);
                string outputPath = System.IO.Path.Combine(outputDir, fileName + ".png");

                var document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}