// Use try‑catch block around Converter.ConvertHTML to capture conversion errors and log exception details.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.mhtml";

            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion succeeded. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}