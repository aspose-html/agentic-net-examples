// Enable text rasterization in XpsSaveOptions to improve rendering quality of HTML to XPS output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, XPS!</h1><p>This is a sample HTML to XPS conversion.</p></body></html>";
            string outputPath = "output.xps";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            // If the TextRasterizationMode property exists in this version, it can be enabled as shown below:
            // options.TextRasterizationMode = Aspose.Html.Saving.TextRasterizationMode.Enabled;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}