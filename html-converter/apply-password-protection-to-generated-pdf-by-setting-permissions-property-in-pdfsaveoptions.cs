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
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions
            {
                Encryption = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                    ownerPassword: "owner123",
                    userPassword: "user123",
                    permissions: Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument |
                                 Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.ExtractContent,
                    encryptionAlgorithm: Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128)
            };

            string outputPath = "protected_output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF generated with password protection.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}