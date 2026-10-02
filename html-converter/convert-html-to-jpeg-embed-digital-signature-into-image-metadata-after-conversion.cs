// Convert HTML to JPEG and embed a digital signature into the image metadata after conversion.

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content and output path
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");

            // Load HTML document from string with base URI
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure image save options for JPEG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Convert HTML to JPEG file
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Embed digital signature into JPEG metadata
            using (var image = Image.FromFile(outputPath))
            {
                // Create a PropertyItem for UserComment (0x9286)
                var propItem = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
                propItem.Id = 0x9286; // PropertyTagUserComment
                string signature = "DigitalSignature:1234567890ABCDEF";
                byte[] signatureBytes = System.Text.Encoding.ASCII.GetBytes(signature);
                propItem.Type = 2; // ASCII
                propItem.Value = signatureBytes;
                propItem.Len = signatureBytes.Length;

                image.SetPropertyItem(propItem);
                image.Save(outputPath, ImageFormat.Jpeg);
            }

            Console.WriteLine("HTML successfully converted to JPEG and signature embedded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}