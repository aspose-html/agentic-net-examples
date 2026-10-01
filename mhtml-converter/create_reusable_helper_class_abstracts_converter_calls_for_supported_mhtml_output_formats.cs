// Create a reusable helper class that abstracts Converter calls for all supported MHTML output formats.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string format = "XPS";
            string outputPath = MhtmlConverterHelper.ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine($"Output file: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

public static class MhtmlConverterHelper
{
    public static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        if (string.IsNullOrEmpty(inputPath))
            throw new ArgumentException("Input path is null or empty.", nameof(inputPath));
        if (!File.Exists(inputPath))
            throw new FileNotFoundException("Input MHTML file not found.", inputPath);
        if (string.IsNullOrEmpty(format))
            throw new ArgumentException("Format is null or empty.", nameof(format));

        string result = null;
        string ext = format.Trim().ToUpperInvariant();

        switch (ext)
        {
            case "XPS":
                {
                    var options = new Aspose.Html.Saving.XpsSaveOptions();
                    string outPath = Path.ChangeExtension(inputPath, ".xps");
                    using (FileStream stream = File.OpenRead(inputPath))
                    {
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outPath);
                    }
                    result = outPath;
                    break;
                }
            case "DOCX":
                {
                    var options = new Aspose.Html.Saving.DocSaveOptions();
                    string outPath = Path.ChangeExtension(inputPath, ".docx");
                    using (FileStream stream = File.OpenRead(inputPath))
                    {
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outPath);
                    }
                    result = outPath;
                    break;
                }
            case "JPEG":
            case "JPG":
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outPath = Path.ChangeExtension(inputPath, ".jpg");
                    using (FileStream stream = File.OpenRead(inputPath))
                    {
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outPath);
                    }
                    result = outPath;
                    break;
                }
            default:
                throw new NotSupportedException($"Format '{format}' is not supported.");
        }

        return result;
    }
}