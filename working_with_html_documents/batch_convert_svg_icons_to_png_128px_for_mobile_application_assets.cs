// Batch convert SVG icons to PNG format at 128 px size for mobile application assets.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace SvgBatchConvert
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "icons/svg";
                string outputFolder = "icons/png";

                Directory.CreateDirectory(outputFolder);

                foreach (string svgPath in Directory.GetFiles(inputFolder, "*.svg"))
                {
                    string fileName = Path.GetFileNameWithoutExtension(svgPath);
                    string pngPath = Path.Combine(outputFolder, fileName + ".png");

                    ImageSaveOptions options = new ImageSaveOptions();

                    Converter.ConvertSVG(svgPath, options, pngPath);
                }

                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}