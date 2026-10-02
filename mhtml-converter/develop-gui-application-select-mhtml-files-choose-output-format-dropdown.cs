// Develop a GUI application that lets users select MHTML files and choose output format from a dropdown.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal sample MHTML file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            // Convert to XPS
            string xpsOutput = ConvertMhtmlByFormat(inputPath, "XPS");
            Console.WriteLine("XPS output: " + xpsOutput);

            // Convert to DOCX
            string docxOutput = ConvertMhtmlByFormat(inputPath, "DOCX");
            Console.WriteLine("DOCX output: " + docxOutput);

            // Convert to JPEG
            string jpegOutput = ConvertMhtmlByFormat(inputPath, "JPEG");
            Console.WriteLine("JPEG output: " + jpegOutput);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        // Open the MHTML file as a stream
        System.IO.FileStream stream = System.IO.File.OpenRead(inputPath);
        string outputDirectory = Path.GetDirectoryName(inputPath);
        string baseFileName = Path.GetFileNameWithoutExtension(inputPath);
        string outputPath;

        if (format.Equals("XPS", StringComparison.OrdinalIgnoreCase))
        {
            outputPath = Path.Combine(outputDirectory, baseFileName + ".xps");
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
        else if (format.Equals("DOCX", StringComparison.OrdinalIgnoreCase))
        {
            outputPath = Path.Combine(outputDirectory, baseFileName + ".docx");
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
        else if (format.Equals("JPEG", StringComparison.OrdinalIgnoreCase))
        {
            outputPath = Path.Combine(outputDirectory, baseFileName + ".jpg");
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
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