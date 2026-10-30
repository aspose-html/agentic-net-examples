// Use static Converter.ConvertSVG(sourcePath, destinationPath) for one‑line SVG to PDF conversion.

namespace AsposeHtmlSvgToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = "sample.svg";
                string outputPath = "output.pdf";

                string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
                System.IO.File.WriteAllText(sourcePath, svgContent);

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

                System.Console.WriteLine("SVG has been successfully converted to PDF.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}