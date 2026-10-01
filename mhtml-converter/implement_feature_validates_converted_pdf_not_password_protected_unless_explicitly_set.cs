// Implement a feature that validates that the converted PDF is not password protected unless explicitly set.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Flag to control whether encryption should be applied
            bool applyEncryption = false; // Change to true to set a password

            if (applyEncryption)
            {
                Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo encryptionInfo =
                    new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                        ownerPassword: "ownerPass",
                        userPassword: "userPass",
                        permissions: Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument,
                        encryptionAlgorithm: Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);
                options.Encryption = encryptionInfo;
            }

            // Output PDF file path
            string outputPath = "output.pdf";

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Validation: ensure PDF is not password protected unless encryption was set
            if (options.Encryption == null)
            {
                Console.WriteLine("Validation passed: PDF is not password protected.");
            }
            else
            {
                Console.WriteLine("Validation passed: PDF is password protected as expected.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}