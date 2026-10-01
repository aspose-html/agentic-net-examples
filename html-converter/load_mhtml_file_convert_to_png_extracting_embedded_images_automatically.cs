// Load an MHTML file and convert it to PNG format, extracting embedded images automatically.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mht";
            string outputPath = "output.png";

            if (!System.IO.File.Exists(inputPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\nSubject: Sample MHTML\r\nDate: Thu, 1 Jan 1970 00:00:00 GMT\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><h1>Hello MHTML</h1></body></html>\r\n------=_NextPart_000_0000--";
                System.IO.File.WriteAllText(inputPath, mhtmlContent);
            }

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            System.Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}