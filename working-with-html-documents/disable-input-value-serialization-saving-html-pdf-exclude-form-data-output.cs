// Disable input value serialization when saving HTML to PDF to exclude form data from the output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a text input
            string htmlContent = "<!DOCTYPE html><html><body><form><input type='text' name='sample'></form></body></html>";
            string baseUri = "about:blank";

            // Load HTML document
            using (HTMLDocument doc = new HTMLDocument(htmlContent, baseUri))
            {
                // Set input value
                HTMLCollection inputElements = doc.GetElementsByTagName("input");
                if (inputElements.Length > 0)
                {
                    HTMLInputElement input = (HTMLInputElement)inputElements[0];
                    input.Value = "SecretData";
                }

                // Save HTML without serializing input values
                string htmlPath = "sample.html";
                HTMLSaveOptions htmlOptions = new HTMLSaveOptions();
                htmlOptions.SerializeInputValue = false;
                doc.Save(htmlPath, htmlOptions);

                // Convert the saved HTML to PDF
                string pdfPath = "output.pdf";
                PdfSaveOptions pdfOptions = new PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, pdfOptions, pdfPath);
            }

            Console.WriteLine("PDF generated successfully without input values.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}