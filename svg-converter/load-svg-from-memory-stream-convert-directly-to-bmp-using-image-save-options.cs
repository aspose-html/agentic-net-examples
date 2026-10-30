// Load an SVG from a memory stream and convert it directly to BMP using ImageSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(memoryStream))
                {
                    writer.Write(svgContent);
                    writer.Flush();
                    memoryStream.Position = 0;

                    string svgCode;
                    using (StreamReader reader = new StreamReader(memoryStream))
                    {
                        svgCode = reader.ReadToEnd();
                    }

                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                    string outputPath = "output.bmp";

                    Aspose.Html.Converters.Converter.ConvertSVG(svgCode, "about:blank", options, outputPath);
                }
            }

            Console.WriteLine("SVG converted to BMP successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}