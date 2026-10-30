// Load an SVG file from a local path into an SVGDocument instance.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.svg";
            string outputPath = "output.svg";

            // Create a minimal SVG file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>";
                System.IO.File.WriteAllText(inputPath, svgContent);
            }

            // Load the SVG document from the file
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(inputPath);

            // Save the SVG document to a new file
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}