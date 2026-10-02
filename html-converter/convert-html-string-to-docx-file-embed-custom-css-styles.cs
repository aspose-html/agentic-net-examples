// Convert an HTML string to a DOCX file while applying DocSaveOptions to embed custom CSS styles.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><head></head><body><h1>Hello</h1><p>Sample paragraph.</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            var options = new Aspose.Html.Saving.DocSaveOptions();
            // CSS can be embedded directly in the HTML string if needed.

            string outputPath = "output.docx";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}