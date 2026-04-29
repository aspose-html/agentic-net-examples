// Write a wrapper function that abstracts Converter.ConvertSVG calls for different target formats.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace SvgConversionWrapper
{
    enum TargetFormat
    {
        Jpeg,
        Pdf,
        Docx,
        Xps
    }

    class Program
    {
        static void Main()
        {
            try
            {
                string svgPath = "input.svg";

                ConvertSvg(svgPath, "output.jpg", TargetFormat.Jpeg);
                ConvertSvg(svgPath, "output.pdf", TargetFormat.Pdf);
                ConvertSvg(svgPath, "output.docx", TargetFormat.Docx);
                ConvertSvg(svgPath, "output.xps", TargetFormat.Xps);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ConvertSvg(string sourcePath, string outputPath, TargetFormat format)
        {
            switch (format)
            {
                case TargetFormat.Jpeg:
                    ImageSaveOptions jpegOptions = new ImageSaveOptions(ImageFormat.Jpeg);
                    Converter.ConvertSVG(sourcePath, jpegOptions, outputPath);
                    break;

                case TargetFormat.Pdf:
                    PdfSaveOptions pdfOptions = new PdfSaveOptions();
                    Converter.ConvertSVG(sourcePath, pdfOptions, outputPath);
                    break;

                case TargetFormat.Docx:
                    DocSaveOptions docxOptions = new DocSaveOptions();
                    Converter.ConvertSVG(sourcePath, docxOptions, outputPath);
                    break;

                case TargetFormat.Xps:
                    XpsSaveOptions xpsOptions = new XpsSaveOptions();
                    Converter.ConvertSVG(sourcePath, xpsOptions, outputPath);
                    break;

                default:
                    throw new ArgumentException("Unsupported target format.");
            }
        }
    }
}