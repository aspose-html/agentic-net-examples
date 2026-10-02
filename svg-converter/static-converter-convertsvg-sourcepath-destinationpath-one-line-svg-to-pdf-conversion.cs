// Use static Converter.ConvertSVG(sourcePath, destinationPath) for one‑line SVG to PDF conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.svg";
            string outputPath = "output.pdf";

            if (!System.IO.File.Exists(sourcePath))
            {
                string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" fill=\"blue\"/></svg>";
                System.IO.File.WriteAllText(sourcePath, svgContent);
            }

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine("SVG converted to PDF successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}