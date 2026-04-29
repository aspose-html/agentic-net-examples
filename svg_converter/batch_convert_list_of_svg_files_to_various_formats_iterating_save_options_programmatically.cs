// Batch convert a list of SVG files to various formats by iterating over save options programmatically.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\ConvertedOutputs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);

                // PNG conversion
                {
                    string pngPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");
                    using (SVGDocument document = new SVGDocument(svgPath))
                    {
                        ImageSaveOptions pngOptions = new ImageSaveOptions();
                        pngOptions.HorizontalResolution = 300;
                        pngOptions.VerticalResolution = 300;
                        pngOptions.BackgroundColor = System.Drawing.Color.White;
                        pngOptions.UseAntialiasing = true;
                        Converter.ConvertSVG(document, pngOptions, pngPath);
                    }
                }

                // JPEG conversion
                {
                    string jpegPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");
                    ImageSaveOptions jpegOptions = new ImageSaveOptions(ImageFormat.Jpeg);
                    Converter.ConvertSVG(svgPath, jpegOptions, jpegPath);
                }

                // PDF conversion with integer margins
                {
                    string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");
                    PdfSaveOptions pdfOptions = new PdfSaveOptions();
                    pdfOptions.PageSetup.AnyPage = new Page(pdfOptions.PageSetup.AnyPage.Size,
                        new Margin(10, 10, 10, 10));
                    Converter.ConvertSVG(svgPath, pdfOptions, pdfPath);
                }

                // DOCX conversion
                {
                    string docxPath = Path.Combine(outputFolder, fileNameWithoutExt + ".docx");
                    DocSaveOptions docOptions = new DocSaveOptions();
                    Converter.ConvertSVG(svgPath, docOptions, docxPath);
                }

                // TIFF conversion
                {
                    string tiffPath = Path.Combine(outputFolder, fileNameWithoutExt + ".tiff");
                    ImageSaveOptions tiffOptions = new ImageSaveOptions(ImageFormat.Tiff);
                    Converter.ConvertSVG(svgPath, tiffOptions, tiffPath);
                }

                // XPS conversion
                {
                    string xpsPath = Path.Combine(outputFolder, fileNameWithoutExt + ".xps");
                    XpsSaveOptions xpsOptions = new XpsSaveOptions();
                    Converter.ConvertSVG(svgPath, xpsOptions, xpsPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(svgPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}