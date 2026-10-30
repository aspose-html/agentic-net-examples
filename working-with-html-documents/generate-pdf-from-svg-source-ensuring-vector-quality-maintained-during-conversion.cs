// Generate a PDF from an SVG source, ensuring vector quality is maintained during conversion.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            System.String svgCode = "<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'><circle cx='100' cy='100' r='80' fill='green' stroke='black' stroke-width='2'/></svg>";
            System.String outputPath = "output.pdf";
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, options, outputPath);
            System.Console.WriteLine("SVG converted to PDF successfully: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}