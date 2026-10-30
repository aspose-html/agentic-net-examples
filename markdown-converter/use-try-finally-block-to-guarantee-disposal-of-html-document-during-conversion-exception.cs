// Use a try‑finally block to guarantee disposal of HtmlDocument even when an exception occurs during conversion.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string documentPath = "sample.html";
            string savePath = "output.xps";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(documentPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                System.IO.File.WriteAllText(documentPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = null;
            try
            {
                document = new Aspose.Html.HTMLDocument(documentPath);
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                Console.WriteLine("Conversion completed. XPS saved at " + savePath);
            }
            finally
            {
                if (document != null)
                {
                    document.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}