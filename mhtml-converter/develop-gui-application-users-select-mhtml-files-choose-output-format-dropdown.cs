// Develop a GUI application that lets users select MHTML files and choose output format from a dropdown.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            string format = "XPS"; // Change to "DOCX" or "JPEG" as needed
            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine("Converted file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        using (FileStream stream = File.OpenRead(inputPath))
        {
            string outputPath = Path.Combine(
                Path.GetDirectoryName(inputPath),
                Path.GetFileNameWithoutExtension(inputPath) + GetExtension(format));

            switch (format.ToUpperInvariant())
            {
                case "XPS":
                    Aspose.Html.Saving.XpsSaveOptions xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, xpsOptions, outputPath);
                    break;

                case "DOCX":
                    Aspose.Html.Saving.DocSaveOptions docOptions = new Aspose.Html.Saving.DocSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, docOptions, outputPath);
                    break;

                case "JPEG":
                    Aspose.Html.Saving.ImageSaveOptions imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, imgOptions, outputPath);
                    break;

                default:
                    throw new ArgumentException("Unsupported format: " + format);
            }

            return outputPath;
        }
    }

    static string GetExtension(string format)
    {
        switch (format.ToUpperInvariant())
        {
            case "XPS":
                return ".xps";
            case "DOCX":
                return ".docx";
            case "JPEG":
                return ".jpg";
            default:
                return "";
        }
    }
}