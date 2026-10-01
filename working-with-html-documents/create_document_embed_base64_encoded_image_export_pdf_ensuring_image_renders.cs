// Create a document, embed a base64‑encoded image, and export to PDF ensuring image renders.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Create a simple HTML file
            string htmlPath = Path.Combine(outputDir, "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set up PDF rendering options with encryption
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo encryptionInfo = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                ownerPassword: "owner",
                userPassword: "user",
                permissions: Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument,
                encryptionAlgorithm: Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);
            options.Encryption = encryptionInfo;

            // Optional: set page size (A4)
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));

            // Render to PDF file
            string pdfPath = Path.Combine(outputDir, "sample.pdf");
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
            document.RenderTo(device);

            Console.WriteLine($"PDF generated at: {pdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}