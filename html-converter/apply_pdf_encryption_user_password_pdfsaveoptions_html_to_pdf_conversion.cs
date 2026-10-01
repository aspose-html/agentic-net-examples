// Apply PDF encryption with user password using PdfSaveOptions during HTML to PDF conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf.Encryption;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML file
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF save options with encryption
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.Encryption = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                ownerPassword: "owner_pwd",
                userPassword: "user_pwd",
                permissions: Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument,
                encryptionAlgorithm: Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);

            // Convert HTML to encrypted PDF
            string outputPath = "encrypted.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}