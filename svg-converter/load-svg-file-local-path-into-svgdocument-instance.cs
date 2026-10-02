// Load an SVG file from a local path into an SVGDocument instance.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                string sampleSvg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>";
                File.WriteAllText(inputPath, sampleSvg);
            }

            Aspose.Html.Dom.Svg.SVGDocument doc = new Aspose.Html.Dom.Svg.SVGDocument(inputPath, "");

            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}