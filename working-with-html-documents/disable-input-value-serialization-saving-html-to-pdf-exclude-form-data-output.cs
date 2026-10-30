// Disable input value serialization when saving HTML to PDF to exclude form data from the output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><form><input type='text' name='field' /></form></body></html>";
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection inputs = doc.GetElementsByTagName("input");
                if (inputs.Length > 0)
                {
                    Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputs[0];
                    input.Value = "SecretValue";
                }

                Aspose.Html.Saving.HTMLSaveOptions htmlOptions = new Aspose.Html.Saving.HTMLSaveOptions();
                htmlOptions.SerializeInputValue = false;
                string tempHtmlPath = "sample.html";
                doc.Save(tempHtmlPath, htmlOptions);

                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(tempHtmlPath, pdfOptions, pdfPath);
                Console.WriteLine("PDF saved to " + pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}