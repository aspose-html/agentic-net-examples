// Apply password protection to generated PDF by setting Permissions property in PdfSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Configure PDF rendering options with password protection
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo encryptionInfo =
                new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                    "owner123",
                    "user123",
                    Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument |
                    Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.ExtractContent,
                    Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);

            options.Encryption = encryptionInfo;

            // Output PDF path
            string outputPath = "protected_output.pdf";

            // Render the document to PDF with the specified options
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine("PDF saved successfully with password protection.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}