// Wrap each ConvertHTML call in a try‑catch block to handle conversion errors and log details.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                string baseUri = "http://example.com/";
                string outputPath = "output.mhtml";

                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

                try
                {
                    Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
                    System.Console.WriteLine("Conversion succeeded. Output saved to: " + outputPath);
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("Error during HTML to MHTML conversion: " + ex.Message);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}