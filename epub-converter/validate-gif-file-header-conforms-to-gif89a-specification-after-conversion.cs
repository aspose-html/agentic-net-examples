// Validate that the GIF file header conforms to the GIF89a specification after conversion.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, GIF!</h1></body></html>";

            // Load HTML from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set GIF image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Output file path
            string outputPath = "output.gif";

            // Convert HTML to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Validate GIF header (should be "GIF89a")
            using (FileStream stream = File.OpenRead(outputPath))
            {
                byte[] headerBytes = new byte[6];
                int bytesRead = stream.Read(headerBytes, 0, headerBytes.Length);
                string header = Encoding.ASCII.GetString(headerBytes, 0, bytesRead);

                if (header == "GIF89a")
                {
                    Console.WriteLine("GIF header is valid (GIF89a).");
                }
                else
                {
                    Console.WriteLine($"Invalid GIF header: \"{header}\"");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}