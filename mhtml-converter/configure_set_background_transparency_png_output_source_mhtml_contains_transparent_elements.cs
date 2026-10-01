// Configure ImageSaveOptions to set background transparency for PNG output when source MHTML contains transparent elements.

using System;
using System.IO;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    File.WriteAllText(inputPath, "<html><body></body></html>");
                }

                using (Stream stream = File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    options.BackgroundColor = Color.Transparent;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine("Conversion completed. Output saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}