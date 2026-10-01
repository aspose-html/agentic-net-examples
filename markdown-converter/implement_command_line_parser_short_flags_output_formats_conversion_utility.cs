// Implement a command‑line argument parser that maps short flags to output formats for the conversion utility.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default input and output
            string htmlPath = "sample.html";
            string outputPath = "output.md";
            string format = "markdown";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Parse command‑line arguments for short flags
            foreach (string arg in args)
            {
                if (arg.StartsWith("-") && arg.Length == 2)
                {
                    char flag = arg[1];
                    switch (flag)
                    {
                        case 'm': // markdown
                            format = "markdown";
                            outputPath = "output.md";
                            break;
                        case 'i': // image (gif)
                            format = "image";
                            outputPath = "output.gif";
                            break;
                        // Add more flags here if needed
                    }
                }
            }

            // Perform conversion based on selected format
            if (format == "markdown")
            {
                Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, outputPath);
                Console.WriteLine($"HTML converted to Markdown: {outputPath}");
            }
            else if (format == "image")
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, outputPath);
                Console.WriteLine($"HTML rendered to Image (GIF): {outputPath}");
            }
            else
            {
                Console.WriteLine("Unsupported format specified.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}