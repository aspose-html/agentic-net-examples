// Write a method that takes SVG paths and returns a dictionary mapping each to its XPS byte array.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample SVG file
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string svgPath = "sample.svg";
            File.WriteAllText(svgPath, svgContent);

            // Set up XPS save options
            var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
            xpsOptions.HorizontalResolution = 300;
            xpsOptions.VerticalResolution = 300;
            xpsOptions.BackgroundColor = System.Drawing.Color.White;

            var page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
            xpsOptions.PageSetup.AnyPage = page;

            // Convert the SVG file to XPS
            string xpsOutput = "output.xps";
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, xpsOptions, xpsOutput);

            // Create an HTML document containing multiple SVG elements
            string htmlContent = $"<html><body>{svgContent}{svgContent}</body></html>";
            var htmlDoc = new Aspose.Html.HTMLDocument(htmlContent);
            Aspose.Html.Collections.HTMLCollection svgs = htmlDoc.GetElementsByTagName("svg");

            // Convert each SVG element to a separate XPS file
            for (int i = 0; i < svgs.Length; i++)
            {
                var element = svgs[i] as Aspose.Html.HTMLElement;
                if (element == null) continue;

                string tempSvgPath = $"temp_{i}.svg";
                File.WriteAllText(tempSvgPath, element.OuterHTML);

                string fileName = $"{i}_output.xps";
                Aspose.Html.Converters.Converter.ConvertSVG(tempSvgPath, xpsOptions, fileName);

                File.Delete(tempSvgPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}