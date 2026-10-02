// Convert an SVG loaded from a memory stream directly to BMP using ConvertSVG overload with ImageSaveOptions.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";

            // Load SVG from a memory stream
            byte[] svgBytes = Encoding.UTF8.GetBytes(svgContent);
            using (MemoryStream memoryStream = new MemoryStream(svgBytes))
            {
                using (StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8, true, 1024, leaveOpen: true))
                {
                    // Reset position to ensure full read
                    memoryStream.Position = 0;
                    string svgCode = reader.ReadToEnd();

                    // Set image save options for BMP format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                    // Output file path
                    string outputPath = "output.bmp";

                    // Convert SVG to BMP
                    Aspose.Html.Converters.Converter.ConvertSVG(svgCode, "about:blank", options, outputPath);
                }
            }

            Console.WriteLine("SVG successfully converted to BMP.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}