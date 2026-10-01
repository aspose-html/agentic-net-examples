// Batch convert a folder of SVG files to BMP format using a loop and Converter.ConvertSVG.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a single sample SVG file
            string sampleSvgPath = "sample.svg";
            if (!File.Exists(sampleSvgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='red' />
</svg>";
                File.WriteAllText(sampleSvgPath, svgContent);
            }

            // Convert the single SVG to BMP
            string bmpOutputPath = "sample.bmp";
            var bmpOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            bmpOptions.HorizontalResolution = 300;
            bmpOptions.VerticalResolution = 300;
            bmpOptions.BackgroundColor = Color.White;
            bmpOptions.UseAntialiasing = true;
            Aspose.Html.Converters.Converter.ConvertSVG(sampleSvgPath, bmpOptions, bmpOutputPath);
            Console.WriteLine($"Converted single SVG to BMP: {bmpOutputPath}");

            // Prepare a folder with multiple SVG files
            string inputFolder = "svgs";
            string outputFolder = "bmp_output";
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a couple of sample SVG files if the folder is empty
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgs.Length == 0)
            {
                for (int n = 1; n <= 3; n++)
                {
                    string path = Path.Combine(inputFolder, $"sample{n}.svg");
                    string content = $@"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <circle cx='100' cy='100' r='80' fill='rgb({n * 50 % 256},{n * 80 % 256},200)' />
</svg>";
                    File.WriteAllText(path, content);
                }
            }

            // Batch convert all SVG files in the folder to BMP
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".bmp");

                using (var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions();
                    options.HorizontalResolution = 200;
                    options.VerticalResolution = 200;
                    options.BackgroundColor = Color.White;
                    options.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outPath)}");
            }

            // Convert one SVG to PDF with custom page setup
            string pdfOutputPath = "sample.pdf";
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
            Aspose.Html.Converters.Converter.ConvertSVG(sampleSvgPath, pdfOptions, pdfOutputPath);
            Console.WriteLine($"Converted SVG to PDF: {pdfOutputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}