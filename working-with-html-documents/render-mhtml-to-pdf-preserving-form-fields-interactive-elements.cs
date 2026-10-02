// Render an MHTML file to PDF while preserving form fields and interactive elements.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            string resultPath = "output.pdf";

            if (!System.IO.File.Exists(sourcePath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\nSubject: Sample\nDate: Thu, 1 Jan 1970 00:00:00 GMT\nMIME-Version: 1.0\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\nContent-Transfer-Encoding: quoted-printable\n\n<html><body><form><input type=\"text\" name=\"name\" value=\"John Doe\"/></form></body></html>\n------=_NextPart_000_0000--";
                System.IO.File.WriteAllText(sourcePath, mhtmlContent);
            }

            var options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, resultPath);

            System.Console.WriteLine("Conversion completed. PDF saved to: " + resultPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}