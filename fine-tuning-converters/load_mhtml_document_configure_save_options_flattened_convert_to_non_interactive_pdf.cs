// Load an MHTML document, configure PdfSaveOptions to Flattened, and convert it to a non‑interactive PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            if (!File.Exists(sourcePath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\nSubject: Test\nDate: Thu, 1 Jan 1970 00:00:00 GMT\nMIME-Version: 1.0\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\nContent-Transfer-Encoding: quoted-printable\n\n<html><body><h1>Hello MHTML</h1></body></html>\n------=_NextPart_000_0000--";
                File.WriteAllText(sourcePath, mhtmlContent);
            }

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            string resultPath = "output.pdf";

            Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, resultPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}