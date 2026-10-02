// Create a PowerShell module that wraps .NET Converter methods for quick MHTML to image conversions.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";

            // Create a minimal MHTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            string outputPath = ConvertMhtmlByFormat(inputPath, "jpeg");
            System.Console.WriteLine("Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
        {
            string outputPath;
            switch (format.ToLowerInvariant())
            {
                case "jpeg":
                case "jpg":
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        options.UseAntialiasing = true;
                        outputPath = System.IO.Path.ChangeExtension(inputPath, ".jpg");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        break;
                    }
                case "png":
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                        options.UseAntialiasing = true;
                        outputPath = System.IO.Path.ChangeExtension(inputPath, ".png");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        break;
                    }
                case "tiff":
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                        options.UseAntialiasing = true;
                        outputPath = System.IO.Path.ChangeExtension(inputPath, ".tiff");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        break;
                    }
                case "xps":
                    {
                        var options = new Aspose.Html.Saving.XpsSaveOptions();
                        outputPath = System.IO.Path.ChangeExtension(inputPath, ".xps");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        break;
                    }
                case "docx":
                    {
                        var options = new Aspose.Html.Saving.DocSaveOptions();
                        outputPath = System.IO.Path.ChangeExtension(inputPath, ".docx");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        break;
                    }
                default:
                    throw new System.ArgumentException("Unsupported format: " + format);
            }
            return outputPath;
        }
    }
}