// Create a command‑line tool that accepts input Markdown path and output format arguments for conversion.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default values
            string sourcePath = "sample.md";
            string outputFormat = "html";
            string outputPath = "output.html";

            // Parse command‑line arguments if provided
            if (args.Length >= 1)
                sourcePath = args[0];
            if (args.Length >= 2)
                outputFormat = args[1].ToLowerInvariant();
            if (args.Length >= 3)
                outputPath = args[2];

            // Ensure the markdown file exists; create a minimal one if missing
            if (!File.Exists(sourcePath))
            {
                string sampleContent = "# Sample Markdown\r\n\r\nThis is a *sample* markdown file.";
                File.WriteAllText(sourcePath, sampleContent);
            }

            // Convert Markdown to temporary HTML file
            string tempHtmlPath = Path.ChangeExtension(Path.GetTempFileName(), ".html");
            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, tempHtmlPath);

            // Perform final conversion based on requested format
            switch (outputFormat)
            {
                case "html":
                    // Simply copy the temporary HTML to the desired output path
                    File.Copy(tempHtmlPath, outputPath, true);
                    break;

                case "pdf":
                    {
                        var options = new Aspose.Html.Saving.PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertHTML(tempHtmlPath, options, outputPath);
                        break;
                    }

                case "png":
                case "jpg":
                case "jpeg":
                case "gif":
                case "bmp":
                case "tiff":
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions();
                        // Set the appropriate image format
                        if (outputFormat == "png")
                            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;
                        else if (outputFormat == "jpg" || outputFormat == "jpeg")
                            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Jpeg;
                        else if (outputFormat == "gif")
                            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Gif;
                        else if (outputFormat == "bmp")
                            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Bmp;
                        else if (outputFormat == "tiff")
                            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Tiff;

                        Aspose.Html.Converters.Converter.ConvertHTML(tempHtmlPath, options, outputPath);
                        break;
                    }

                default:
                    Console.WriteLine($"Unsupported output format: {outputFormat}");
                    break;
            }

            // Clean up temporary file
            if (File.Exists(tempHtmlPath))
                File.Delete(tempHtmlPath);

            Console.WriteLine($"Conversion completed. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}