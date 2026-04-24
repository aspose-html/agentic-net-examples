// Apply password protection to generated PDF by setting Permissions property in PdfSaveOptions.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf.Encryption;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPdf = "output.pdf";
            string userPassword = "user123";
            string ownerPassword = "owner123";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo encryptionInfo = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                ownerPassword,
                userPassword,
                Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument | Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.ExtractContent,
                Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);
            options.Encryption = encryptionInfo;
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}