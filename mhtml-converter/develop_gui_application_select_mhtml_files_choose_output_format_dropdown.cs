// Develop a GUI application that lets users select MHTML files and choose output format from a dropdown.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "Dummy MHTML content");
            }

            string format = "XPS"; // Change to "DOCX" or "JPEG" as needed
            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine("Converted file saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        string outputPath;
        using (FileStream stream = File.OpenRead(inputPath))
        {
            if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                outputPath = Path.ChangeExtension(inputPath, ".xps");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            else if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
            {
                DocSaveOptions options = new DocSaveOptions();
                outputPath = Path.ChangeExtension(inputPath, ".docx");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            else if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                outputPath = Path.ChangeExtension(inputPath, ".jpg");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
            else
            {
                throw new ArgumentException("Unsupported format: " + format);
            }
        }
        return outputPath;
    }
}