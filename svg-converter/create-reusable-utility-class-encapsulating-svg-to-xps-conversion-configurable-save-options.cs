// Create a reusable utility class that encapsulates SVG to XPS conversion with configurable save options.

namespace SvgToXpsExample
{
    class SvgToXpsConverter
    {
        public void Convert(string sourcePath, string outputPath, int horizontalResolution, int verticalResolution, System.Drawing.Color backgroundColor, Aspose.Html.Drawing.Page pageSetup)
        {
            using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(sourcePath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.HorizontalResolution = horizontalResolution;
                options.VerticalResolution = verticalResolution;
                options.BackgroundColor = backgroundColor;
                options.PageSetup.AnyPage = pageSetup;
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = "sample.svg";
                string outputPath = "output.xps";

                if (!System.IO.File.Exists(sourcePath))
                {
                    string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                    System.IO.File.WriteAllText(sourcePath, svgContent);
                }

                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(800, 600);
                Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(10, 10, 10, 10);
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);

                SvgToXpsConverter converter = new SvgToXpsConverter();
                converter.Convert(sourcePath, outputPath, 300, 300, System.Drawing.Color.AliceBlue, page);

                System.Console.WriteLine("Conversion completed successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}