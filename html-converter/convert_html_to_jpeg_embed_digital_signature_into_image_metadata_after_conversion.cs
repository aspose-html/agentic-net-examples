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
            // Define input HTML and output JPEG paths
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Configure image save options for JPEG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to JPEG and save to file
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Embed a digital signature into JPEG metadata (UserComment tag)
            string digitalSignature = "SignedBy=JohnDoe;Timestamp=2026-09-23T12:00:00Z";

            using (Image img = Image.FromFile(outputPath))
            {
                // Create a PropertyItem instance via FormatterServices
                PropertyItem prop = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
                prop.Id = 0x9286; // PropertyTagUserComment
                prop.Type = 2; // ASCII
                byte[] valueBytes = System.Text.Encoding.ASCII.GetBytes(digitalSignature + '\0');
                prop.Value = valueBytes;
                prop.Len = valueBytes.Length;

                img.SetPropertyItem(prop);
                img.Save(outputPath, ImageFormat.Jpeg);
            }

            Console.WriteLine("HTML converted to JPEG and digital signature embedded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}