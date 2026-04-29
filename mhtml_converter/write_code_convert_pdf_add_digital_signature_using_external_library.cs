// Write code to convert PDF and then add a digital signature using an external library.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace PdfConversionAndSignature
{
    class Program
    {
        static void Main()
        {
            try
            {
                string markdownPath = "input.md";
                string pdfPath = "output.pdf";

                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);
                Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.PdfSaveOptions(), pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}