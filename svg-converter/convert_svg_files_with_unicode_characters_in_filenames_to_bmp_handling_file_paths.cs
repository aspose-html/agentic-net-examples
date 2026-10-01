// Convert SVG files with Unicode characters in filenames to BMP, ensuring correct handling of file paths.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string code = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            string outputPath = "output.bmp";

            string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            Aspose.Html.Converters.Converter.ConvertSVG(code, ".", options, outputPath);

            Console.WriteLine("SVG converted to BMP successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}