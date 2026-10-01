// Create a PowerShell module that wraps .NET Converter methods for quick MHTML to image conversions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            string outputPath = ConvertMhtmlByFormat(inputPath, "PNG");
            System.Console.WriteLine("Conversion successful. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        System.IO.Stream stream = System.IO.File.OpenRead(inputPath);
        string outputPath;

        if (format.Equals("PNG", StringComparison.OrdinalIgnoreCase))
        {
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            outputPath = System.IO.Path.ChangeExtension(inputPath, ".png");
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
        else if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase) || format.Equals("JPG", StringComparison.OrdinalIgnoreCase))
        {
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            outputPath = System.IO.Path.ChangeExtension(inputPath, ".jpg");
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
        else if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
        {
            var options = new Aspose.Html.Saving.XpsSaveOptions();
            outputPath = System.IO.Path.ChangeExtension(inputPath, ".xps");
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
        else if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
        {
            var options = new Aspose.Html.Saving.DocSaveOptions();
            outputPath = System.IO.Path.ChangeExtension(inputPath, ".docx");
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
        else
        {
            stream.Dispose();
            throw new ArgumentException("Unsupported format: " + format);
        }

        stream.Dispose();
        return outputPath;
    }
}