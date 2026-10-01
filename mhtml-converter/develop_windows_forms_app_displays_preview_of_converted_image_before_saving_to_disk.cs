// Develop a Windows Forms app that displays a preview of the converted image before saving to disk.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            string outputPath = ConvertMhtmlByFormat(inputPath, "JPEG");
            Console.WriteLine("Converted image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        string outputPath;
        if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
        {
            outputPath = Path.ChangeExtension(inputPath, ".xps");
            var options = new Aspose.Html.Saving.XpsSaveOptions();
            using (var inputStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
            }
        }
        else if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
        {
            outputPath = Path.ChangeExtension(inputPath, ".docx");
            var options = new Aspose.Html.Saving.DocSaveOptions();
            using (var inputStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
            }
        }
        else if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase) || format.Equals("JPG", StringComparison.OrdinalIgnoreCase))
        {
            outputPath = Path.ChangeExtension(inputPath, ".jpg");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            using (var inputStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
            }
        }
        else
        {
            throw new ArgumentException("Unsupported format");
        }

        return outputPath;
    }
}