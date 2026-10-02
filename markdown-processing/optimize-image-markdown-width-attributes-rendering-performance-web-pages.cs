// Optimize image markdown by adding width attributes to improve rendering performance on web pages.

using System;

namespace OptimizeImageMarkdown
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample markdown containing an image
                string markdown = "## Sample\n\nHere is an image:\n\n![Sample Image](sample.jpg)";

                // Convert markdown to an HTML document
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

                // Add width attribute to all <img> elements
                var images = document.GetElementsByTagName("img");
                foreach (Aspose.Html.HTMLElement img in images)
                {
                    img.SetAttribute("width", "600");
                }

                // Save the modified HTML to a file
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"HTML saved to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}