// Convert HTML to DOCX while embedding all linked CSS files into the resulting document.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.docx";

            HTMLDocument document = new HTMLDocument(htmlPath);
            DocSaveOptions options = new DocSaveOptions();
            Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}