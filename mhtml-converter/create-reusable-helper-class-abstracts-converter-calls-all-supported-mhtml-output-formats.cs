// Create a reusable helper class that abstracts Converter calls for all supported MHTML output formats.

using System;
using System.IO;

public static class MhtmlConverterHelper
{
    public static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        if (string.IsNullOrEmpty(inputPath))
            throw new ArgumentException("Input path is null or empty.", nameof(inputPath));
        if (string.IsNullOrEmpty(format))
            throw new ArgumentException("Format is null or empty.", nameof(format));

        string outputPath;
        string directory = Path.GetDirectoryName(inputPath) ?? Directory.GetCurrentDirectory();
        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

        using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
        {
            switch (format.Trim().ToUpperInvariant())
            {
                case "XPS":
                    {
                        Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                        outputPath = Path.Combine(directory, fileNameWithoutExt + ".xps");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        break;
                    }
                case "DOCX":
                    {
                        Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                        outputPath = Path.Combine(directory, fileNameWithoutExt + ".docx");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        break;
                    }
                case "JPEG":
                case "JPG":
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        outputPath = Path.Combine(directory, fileNameWithoutExt + ".jpg");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                        break;
                    }
                default:
                    throw new NotSupportedException($"The format '{format}' is not supported.");
            }
        }

        return outputPath;
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Prepare a minimal MHTML file for demonstration purposes
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML!</h1></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            // Convert to XPS as an example
            string resultPath = MhtmlConverterHelper.ConvertMhtmlByFormat(inputPath, "XPS");
            Console.WriteLine($"Conversion successful. Output file: {resultPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}