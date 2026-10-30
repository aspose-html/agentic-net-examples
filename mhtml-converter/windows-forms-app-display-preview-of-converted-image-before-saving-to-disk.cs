// Develop a Windows Forms app that displays a preview of the converted image before saving to disk.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal MHTML file (empty content for demonstration)
            string inputPath = "sample.mhtml";
            File.WriteAllText(inputPath, string.Empty);

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
        if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
        {
            var options = new Aspose.Html.Saving.XpsSaveOptions();
            string outputPath = Path.ChangeExtension(inputPath, ".xps");
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
            return outputPath;
        }
        else if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
        {
            var options = new Aspose.Html.Saving.DocSaveOptions();
            string outputPath = Path.ChangeExtension(inputPath, ".docx");
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
            return outputPath;
        }
        else if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase))
        {
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            string outputPath = Path.ChangeExtension(inputPath, ".jpg");
            Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
            return outputPath;
        }
        else
        {
            throw new ArgumentException("Unsupported format: " + format);
        }
    }
}