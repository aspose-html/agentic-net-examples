// Embed fonts in PdfSaveOptions during SVG to PDF conversion for consistent text appearance.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string svgCode = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><text x='10' y='20' font-family='Arial' font-size='16'>Hello</text></svg>";
            string baseUri = "";
            PdfSaveOptions options = new PdfSaveOptions();
            // If the PdfSaveOptions class supports font embedding, you can enable it as shown below:
            // options.FontEmbeddingMode = Aspose.Html.Saving.FontEmbeddingMode.EmbedAll;
            string outputPath = "output.pdf";
            Converter.ConvertSVG(svgCode, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}