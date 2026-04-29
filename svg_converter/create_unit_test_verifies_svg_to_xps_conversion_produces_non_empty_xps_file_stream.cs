// Create a unit test that verifies SVG to XPS conversion produces a non‑empty XPS file stream.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare temporary SVG content
            string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            string sourcePath = Path.Combine(Path.GetTempPath(), "temp.svg");
            File.WriteAllText(sourcePath, svgContent);

            // Define output XPS path
            string outputPath = Path.Combine(Path.GetTempPath(), "output.xps");

            // Create XPS save options (default)
            XpsSaveOptions options = new XpsSaveOptions();

            // Convert SVG file to XPS file
            Converter.ConvertSVG(sourcePath, options, outputPath);

            // Verify that the generated XPS file is non‑empty
            using (FileStream stream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            {
                if (stream.Length > 0)
                {
                    Console.WriteLine("Conversion succeeded: XPS stream is non‑empty.");
                }
                else
                {
                    Console.WriteLine("Conversion failed: XPS stream is empty.");
                }
            }

            // Clean up temporary files
            File.Delete(sourcePath);
            File.Delete(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}