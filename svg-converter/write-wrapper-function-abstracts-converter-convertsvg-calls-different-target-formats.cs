// Write a wrapper function that abstracts Converter.ConvertSVG calls for different target formats.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string svg = "<svg width=\"100\" height=\"100\" xmlns=\"http://www.w3.org/2000/svg\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>";
            string outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);

            ConvertSvg(svg, System.IO.Path.Combine(outputDir, "circle.jpg"), "jpeg");
            ConvertSvg(svg, System.IO.Path.Combine(outputDir, "circle.tiff"), "tiff");
            ConvertSvg(svg, System.IO.Path.Combine(outputDir, "circle.pdf"), "pdf");

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertSvg(string svgContent, string outputPath, string format)
    {
        if (format == null) throw new ArgumentNullException(nameof(format));
        switch (format.ToLowerInvariant())
        {
            case "jpeg":
                var jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, jpegOptions, outputPath);
                break;
            case "tiff":
                var tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
                tiffOptions.HorizontalResolution = 300;
                tiffOptions.VerticalResolution = 300;
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, tiffOptions, outputPath);
                break;
            case "pdf":
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, pdfOptions, outputPath);
                break;
            default:
                throw new ArgumentException($"Unsupported format: {format}");
        }
    }
}