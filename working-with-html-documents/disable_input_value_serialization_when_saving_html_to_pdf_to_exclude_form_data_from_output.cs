// Disable input value serialization when saving HTML to PDF to exclude form data from the output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body><form><input type='text' name='sample' value=''></form></body></html>";
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html, string.Empty))
            {
                Aspose.Html.Collections.HTMLCollection inputs = doc.GetElementsByTagName("input");
                Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputs[0];
                input.Value = "Secret";

                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = "output.pdf";

                Aspose.Html.Converters.Converter.ConvertHTML(doc, pdfOptions, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}