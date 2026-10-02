// Leverage the default save options to quickly convert SVG to XPS without specifying additional parameters.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "sample.svg";
            string outputPath = "output.xps";

            if (!File.Exists(sourcePath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' /></svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            XpsSaveOptions options = new XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine("SVG converted to XPS successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}