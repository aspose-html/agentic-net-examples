// Create a PowerShell module that wraps .NET Converter methods for quick MHTML to image conversions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input MHTML file (create a minimal placeholder if it does not exist)
            string inputPath = "sample.mhtml";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Sample MHTML Content</h1></body></html>");
            }

            // Desired output format (e.g., "png", "jpeg", "bmp", "tiff", "xps", "docx")
            string format = "png";

            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine($"Conversion succeeded. Output file: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        if (string.IsNullOrEmpty(inputPath))
            throw new ArgumentException("Input path must be provided.", nameof(inputPath));
        if (string.IsNullOrEmpty(format))
            throw new ArgumentException("Format must be provided.", nameof(format));

        string outputPath;
        object options;

        switch (format.Trim().ToUpperInvariant())
        {
            case "PNG":
                outputPath = Path.ChangeExtension(inputPath, ".png");
                options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
                {
                    UseAntialiasing = true
                };
                break;
            case "JPEG":
            case "JPG":
                outputPath = Path.ChangeExtension(inputPath, ".jpg");
                options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg)
                {
                    UseAntialiasing = true
                };
                break;
            case "BMP":
                outputPath = Path.ChangeExtension(inputPath, ".bmp");
                options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp)
                {
                    UseAntialiasing = true
                };
                break;
            case "TIFF":
                outputPath = Path.ChangeExtension(inputPath, ".tiff");
                options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    UseAntialiasing = true
                };
                break;
            case "XPS":
                outputPath = Path.ChangeExtension(inputPath, ".xps");
                options = new Aspose.Html.Saving.XpsSaveOptions();
                break;
            case "DOCX":
                outputPath = Path.ChangeExtension(inputPath, ".docx");
                options = new Aspose.Html.Saving.DocSaveOptions();
                break;
            default:
                throw new NotSupportedException($"The format '{format}' is not supported.");
        }

        using (Stream stream = File.OpenRead(inputPath))
        {
            // The ConvertMHTML overload expects the specific SaveOptions type.
            if (options is Aspose.Html.Saving.ImageSaveOptions imgOpts)
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, imgOpts, outputPath);
            }
            else if (options is Aspose.Html.Saving.XpsSaveOptions xpsOpts)
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, xpsOpts, outputPath);
            }
            else if (options is Aspose.Html.Saving.DocSaveOptions docOpts)
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, docOpts, outputPath);
            }
            else
            {
                throw new InvalidOperationException("Unsupported save options type.");
            }
        }

        return outputPath;
    }
}