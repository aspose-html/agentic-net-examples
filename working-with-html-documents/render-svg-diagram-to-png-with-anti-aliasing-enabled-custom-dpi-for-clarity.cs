// Render an SVG diagram to PNG with anti‑aliasing enabled and custom DPI for clarity.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.String inputPath = "sample.svg";
                System.String outputPath = "output.png";

                if (!System.IO.File.Exists(inputPath))
                {
                    System.String svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><circle cx='100' cy='100' r='80' fill='green' stroke='black' stroke-width='5'/></svg>";
                    System.IO.File.WriteAllText(inputPath, svgContent);
                }

                Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(inputPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.UseAntialiasing = true;

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                System.Console.WriteLine("SVG converted to PNG successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}