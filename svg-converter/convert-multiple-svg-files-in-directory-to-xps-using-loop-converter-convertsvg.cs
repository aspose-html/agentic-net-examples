// Convert multiple SVG files in a directory to XPS using a loop with Converter.ConvertSVG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputXps";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder); // Ensure folder exists for demo

            // Example: create a sample SVG if none exist
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
                    @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
                        <rect width='200' height='200' fill='lightblue'/>
                        <circle cx='100' cy='100' r='80' fill='orange'/>
                      </svg>");
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            foreach (string svgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string xpsPath = Path.Combine(outputFolder, fileName + ".xps");

                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, xpsPath);

                Console.WriteLine($"Converted '{Path.GetFileName(svgPath)}' to '{Path.GetFileName(xpsPath)}'");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}