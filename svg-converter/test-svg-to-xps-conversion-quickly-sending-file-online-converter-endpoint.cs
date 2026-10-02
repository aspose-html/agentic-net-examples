// Test SVG to XPS conversion quickly by sending the file to the online converter endpoint.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.svg";
            string outputPath = "output.xps";

            if (!File.Exists(sourcePath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            XpsSaveOptions options = new XpsSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.AliceBlue;

            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);
            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}