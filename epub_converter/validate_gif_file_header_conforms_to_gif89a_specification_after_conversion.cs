// Validate that the GIF file header conforms to the GIF89a specification after conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello GIF</h1></body></html>";
            string outputPath = "output.gif";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            using (FileStream fs = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            {
                byte[] header = new byte[6];
                int bytesRead = fs.Read(header, 0, 6);
                string headerString = System.Text.Encoding.ASCII.GetString(header);
                if (headerString == "GIF89a")
                {
                    Console.WriteLine("GIF header is valid (GIF89a).");
                }
                else
                {
                    Console.WriteLine($"Invalid GIF header: {headerString}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}