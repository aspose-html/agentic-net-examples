// Write a console application that reads SVG file paths from a text file and converts them to XPS.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare data directory
            string dataDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data");
            if (!System.IO.Directory.Exists(dataDir))
            {
                System.IO.Directory.CreateDirectory(dataDir);
            }

            // Create a minimal SVG file if it does not exist
            string sampleSvgPath = System.IO.Path.Combine(dataDir, "sample.svg");
            if (!System.IO.File.Exists(sampleSvgPath))
            {
                string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
                System.IO.File.WriteAllText(sampleSvgPath, svgContent);
            }

            // Create a list file containing SVG paths if it does not exist
            string listPath = System.IO.Path.Combine(dataDir, "svglist.txt");
            if (!System.IO.File.Exists(listPath))
            {
                System.IO.File.WriteAllText(listPath, sampleSvgPath);
            }

            // Read SVG file paths from the list
            string[] svgPaths = System.IO.File.ReadAllLines(listPath);
            foreach (string sourcePath in svgPaths)
            {
                if (string.IsNullOrWhiteSpace(sourcePath))
                    continue;

                string outputPath = System.IO.Path.Combine(dataDir, System.IO.Path.GetFileNameWithoutExtension(sourcePath) + ".xps");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(sourcePath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.AliceBlue;

                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(800, 600),
                        new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
                    options.PageSetup.AnyPage = page;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                Console.WriteLine($"Converted '{sourcePath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}