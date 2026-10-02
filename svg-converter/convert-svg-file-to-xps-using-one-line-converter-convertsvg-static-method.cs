// Convert an SVG file to XPS using the one‑line Converter.ConvertSVG static method.

namespace Example
{
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
                    string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                    System.IO.File.WriteAllText(sourcePath, svgContent);
                }

                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

                System.Console.WriteLine("SVG converted to XPS successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}