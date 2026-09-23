// Validate that the GIF file header conforms to the GIF89a specification after conversion.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, GIF!</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent, Encoding.UTF8);

            // Define output GIF path
            string outputPath = "output.gif";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set image save options for GIF
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Convert HTML to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Validate GIF header
            using (FileStream stream = File.OpenRead(outputPath))
            {
                byte[] headerBytes = new byte[6];
                int bytesRead = stream.Read(headerBytes, 0, headerBytes.Length);
                if (bytesRead != headerBytes.Length)
                {
                    Console.WriteLine("Failed to read GIF header.");
                    return;
                }

                string header = System.Text.Encoding.ASCII.GetString(headerBytes);
                if (header == "GIF89a")
                {
                    Console.WriteLine("GIF header is valid (GIF89a).");
                }
                else
                {
                    Console.WriteLine($"Invalid GIF header: {header}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}