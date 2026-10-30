// Wrap each ConvertHTML call in a try‑catch block to handle conversion errors and log details.

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

            try
            {
                Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
                Console.WriteLine("HTML successfully converted to MHTML.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during conversion: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}