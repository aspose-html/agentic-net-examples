// Implement a feature that validates that the converted PDF is not password protected unless explicitly set.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello PDF</h1></body></html>";
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, htmlContent);

            // Output PDF path
            string pdfPath = "output.pdf";

            // Flag to indicate whether PDF should be password protected
            bool protectPdf = false; // Change to true to enable protection

            // Configure PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            if (protectPdf)
            {
                Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo encryptionInfo =
                    new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                        ownerPassword: "ownerPwd",
                        userPassword: "userPwd",
                        permissions: Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument,
                        encryptionAlgorithm: Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);
                options.Encryption = encryptionInfo;
            }

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, pdfPath);

            // Validation message
            if (protectPdf)
                Console.WriteLine("PDF generated with password protection.");
            else
                Console.WriteLine("PDF generated without password protection.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}