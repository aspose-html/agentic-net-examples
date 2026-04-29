// Create a reusable helper class that abstracts Converter calls for all supported MHTML output formats.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace MhtmlConversionHelperApp
{
    // Helper class that abstracts conversion of MHTML to various formats
    public static class MhtmlConverterHelper
    {
        // Convert MHTML to XPS
        public static string ConvertToXps(string inputPath, string outputDirectory)
        {
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".xps");
            using (FileStream stream = File.OpenRead(inputPath))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                Converter.ConvertMHTML(stream, options, outputPath);
            }
            return outputPath;
        }

        // Convert MHTML to DOCX
        public static string ConvertToDocx(string inputPath, string outputDirectory)
        {
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".docx");
            using (FileStream stream = File.OpenRead(inputPath))
            {
                DocSaveOptions options = new DocSaveOptions();
                Converter.ConvertMHTML(stream, options, outputPath);
            }
            return outputPath;
        }

        // Convert MHTML to PDF
        public static string ConvertToPdf(string inputPath, string outputDirectory)
        {
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
            using (FileStream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertMHTML(stream, options, outputPath);
            }
            return outputPath;
        }

        // Convert MHTML to an image (JPEG, PNG, etc.)
        public static string ConvertToImage(string inputPath, string outputDirectory, string format)
        {
            string extension = format.ToLower() == "png" ? ".png" : ".jpg";
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + extension);
            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageFormat imgFormat = format.ToLower() == "png"
                    ? ImageFormat.Png
                    : ImageFormat.Jpeg;
                ImageSaveOptions options = new ImageSaveOptions(imgFormat);
                Converter.ConvertMHTML(stream, options, outputPath);
            }
            return outputPath;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Input MHTML file
                string inputMhtml = "sample.mhtml";

                // Output directory (ensure it exists)
                string outputDir = "output";
                Directory.CreateDirectory(outputDir);

                // Perform conversions
                string xpsPath = MhtmlConverterHelper.ConvertToXps(inputMhtml, outputDir);
                Console.WriteLine($"XPS created at: {xpsPath}");

                string docxPath = MhtmlConverterHelper.ConvertToDocx(inputMhtml, outputDir);
                Console.WriteLine($"DOCX created at: {docxPath}");

                string pdfPath = MhtmlConverterHelper.ConvertToPdf(inputMhtml, outputDir);
                Console.WriteLine($"PDF created at: {pdfPath}");

                string jpegPath = MhtmlConverterHelper.ConvertToImage(inputMhtml, outputDir, "jpeg");
                Console.WriteLine($"JPEG image created at: {jpegPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}