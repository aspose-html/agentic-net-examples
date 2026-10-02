// Create a unit test that verifies SVG to XPS conversion produces a non‑empty XPS file stream.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            string svgPath = Path.Combine(Path.GetTempPath(), "sample.svg");
            string xpsPath = Path.Combine(Path.GetTempPath(), "output.xps");

            // Write SVG to a temporary file
            File.WriteAllText(svgPath, svgContent);

            // Convert SVG to XPS
            XpsSaveOptions options = new XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, xpsPath);

            // Verify the XPS file is non‑empty
            using (FileStream stream = File.OpenRead(xpsPath))
            {
                if (stream.Length > 0)
                {
                    Console.WriteLine($"XPS conversion succeeded. File size: {stream.Length} bytes.");
                }
                else
                {
                    Console.WriteLine("XPS conversion failed: generated file is empty.");
                }
            }

            // Cleanup temporary files (optional)
            File.Delete(svgPath);
            File.Delete(xpsPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}