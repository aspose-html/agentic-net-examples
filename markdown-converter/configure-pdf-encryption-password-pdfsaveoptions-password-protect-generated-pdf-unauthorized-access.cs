// Configure PDF encryption password via PdfSaveOptions.Password to protect the generated PDF from unauthorized access.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf.Encryption;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            // Create HTMLDocument from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure PDF save options with encryption
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.Encryption = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                ownerPassword: "owner123",
                userPassword: "user123",
                permissions: Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument |
                             Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.ExtractContent,
                encryptionAlgorithm: Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);

            // Output PDF path
            string outputPath = "encrypted_output.pdf";

            // Convert HTML to encrypted PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"PDF successfully saved to '{outputPath}' with encryption.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}