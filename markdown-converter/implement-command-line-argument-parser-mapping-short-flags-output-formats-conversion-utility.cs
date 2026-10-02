// Implement a command‑line argument parser that maps short flags to output formats for the conversion utility.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default input HTML file
            string htmlPath = "sample.html";
            // Ensure sample HTML exists
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Default output base name
            string outputBase = "output";

            // Default format is Markdown
            string format = "md";

            // Parse command‑line arguments for short flags
            foreach (string arg in args)
            {
                if (arg.StartsWith("-"))
                {
                    string flag = arg.TrimStart('-').ToLowerInvariant();
                    if (flag == "m" || flag == "md")
                    {
                        format = "md";
                    }
                    else if (flag == "i" || flag == "img")
                    {
                        format = "img";
                    }
                }
            }

            if (format == "md")
            {
                // Convert HTML to Markdown
                Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
                string savePath = outputBase + ".md";
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);
                Console.WriteLine($"HTML converted to Markdown: {savePath}");
            }
            else if (format == "img")
            {
                // Convert HTML to GIF image
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                string savePath = outputBase + ".gif";
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);
                Console.WriteLine($"HTML converted to GIF image: {savePath}");
            }
            else
            {
                Console.WriteLine("Unsupported format flag. Use -m for Markdown or -i for Image.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}