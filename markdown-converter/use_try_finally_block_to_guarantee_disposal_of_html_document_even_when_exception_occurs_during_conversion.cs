// Use a try‑finally block to guarantee disposal of HtmlDocument even when an exception occurs during conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "input.html";
            string savePath = "output.xps";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(documentPath))
            {
                File.WriteAllText(documentPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            try
            {
                // Set conversion options
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

                Console.WriteLine("Conversion completed. XPS saved at " + savePath);
            }
            finally
            {
                // Ensure the document is disposed even if an exception occurs
                document.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}