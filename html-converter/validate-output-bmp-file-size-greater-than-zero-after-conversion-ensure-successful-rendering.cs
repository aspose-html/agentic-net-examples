// Validate that the output BMP file size is greater than zero after conversion to ensure successful rendering.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input SVG and output BMP paths
            string svgPath = "sample.svg";
            string outputPath = "output.bmp";

            // Create a minimal SVG file
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            System.IO.File.WriteAllText(svgPath, svgContent);

            // Set up BMP save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            // Validate output file size
            long fileSize = new System.IO.FileInfo(outputPath).Length;
            if (fileSize > 0)
            {
                System.Console.WriteLine("BMP conversion succeeded. File size: " + fileSize + " bytes.");
            }
            else
            {
                System.Console.WriteLine("BMP conversion failed. Output file size is zero.");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}