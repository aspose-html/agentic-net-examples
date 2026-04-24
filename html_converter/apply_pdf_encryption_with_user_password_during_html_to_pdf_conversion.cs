// Apply PDF encryption with user password using PdfSaveOptions during HTML to PDF conversion.

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
            // Input HTML file and output PDF file paths
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            // Owner and user passwords for PDF encryption
            string ownerPassword = "owner123";
            string userPassword = "user123";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Configure encryption with passwords, permissions, and algorithm
            PdfEncryptionInfo encryptionInfo = new PdfEncryptionInfo(
                ownerPassword: ownerPassword,
                userPassword: userPassword,
                permissions: PdfPermissions.PrintDocument | PdfPermissions.ExtractContent,
                encryptionAlgorithm: PdfEncryptionAlgorithm.RC4_128);

            options.Encryption = encryptionInfo;

            // Convert HTML to encrypted PDF
            Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}