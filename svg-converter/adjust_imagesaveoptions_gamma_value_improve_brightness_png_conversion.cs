// Adjust ImageSaveOptions gamma value to improve brightness for PNG conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mht";
            string outputPath = "output.png";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string simpleHtml = "<html><body><h1>Hello MHTML</h1></body></html>";
                string mhtmlContent =
                    "From: <Saved by Example>\r\n" +
                    "Subject: Sample MHTML\r\n" +
                    "MIME-Version: 1.0\r\n" +
                    "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                    "------=_NextPart_000_0000\r\n" +
                    "Content-Type: text/html; charset=\"utf-8\"\r\n" +
                    "Content-Transfer-Encoding: quoted-printable\r\n\r\n" +
                    simpleHtml + "\r\n" +
                    "------=_NextPart_000_0000--";

                File.WriteAllText(inputPath, mhtmlContent);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}