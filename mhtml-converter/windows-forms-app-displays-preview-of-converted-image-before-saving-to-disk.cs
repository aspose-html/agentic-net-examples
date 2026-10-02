// Develop a Windows Forms app that displays a preview of the converted image before saving to disk.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file to act as input
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Convert to XPS
            string xpsPath = ConvertMhtmlByFormat(inputPath, "XPS");
            Console.WriteLine("XPS output: " + xpsPath);

            // Convert to DOCX
            string docxPath = ConvertMhtmlByFormat(inputPath, "DOCX");
            Console.WriteLine("DOCX output: " + docxPath);

            // Convert to JPEG
            string jpegPath = ConvertMhtmlByFormat(inputPath, "JPEG");
            Console.WriteLine("JPEG output: " + jpegPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        if (string.IsNullOrEmpty(inputPath))
            throw new ArgumentException("Input path is null or empty.", nameof(inputPath));

        string outputPath;
        switch (format?.ToUpperInvariant())
        {
            case "XPS":
                outputPath = Path.ChangeExtension(inputPath, ".xps");
                var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
                using (var inputStream = File.OpenRead(inputPath))
                {
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, xpsOptions, outputPath);
                }
                break;

            case "DOCX":
                outputPath = Path.ChangeExtension(inputPath, ".docx");
                var docOptions = new Aspose.Html.Saving.DocSaveOptions();
                using (var inputStream = File.OpenRead(inputPath))
                {
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, docOptions, outputPath);
                }
                break;

            case "JPEG":
                outputPath = Path.ChangeExtension(inputPath, ".jpg");
                var imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                using (var inputStream = File.OpenRead(inputPath))
                {
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, imgOptions, outputPath);
                }
                break;

            default:
                throw new ArgumentException($"Unsupported format: {format}");
        }

        return outputPath;
    }
}