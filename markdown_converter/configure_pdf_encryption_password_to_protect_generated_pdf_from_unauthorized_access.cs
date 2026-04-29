// Configure PDF encryption password via PdfSaveOptions.Password to protect the generated PDF from unauthorized access.

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
            // Load the HTML document from a file
            HTMLDocument document = new HTMLDocument("input.html");

            // Create PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Configure PDF encryption with owner and user passwords
            PdfEncryptionInfo encryptionInfo = new PdfEncryptionInfo(
                ownerPassword: "owner123",
                userPassword: "user123",
                permissions: PdfPermissions.PrintDocument | PdfPermissions.ExtractContent,
                encryptionAlgorithm: PdfEncryptionAlgorithm.RC4_128);

            // Assign encryption settings to the save options
            options.Encryption = encryptionInfo;

            // Convert the HTML document to an encrypted PDF file
            Converter.ConvertHTML(document, options, "output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}