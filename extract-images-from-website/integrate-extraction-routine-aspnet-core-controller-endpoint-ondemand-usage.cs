// Integrate the extraction routine into an ASP.NET Core controller endpoint for on‑demand usage.

public sealed class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            if (!System.IO.File.Exists(inputPath))
            {
                string minimalMhtml = "From: <Saved by WebKit>\r\nSubject: Sample MHTML\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000_01D4C0A0.12345678\"\r\n\r\n------=_NextPart_000_0000_01D4C0A0.12345678\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><p>Hello, MHTML!</p></body></html>\r\n------=_NextPart_000_0000_01D4C0A0.12345678--";
                System.IO.File.WriteAllText(inputPath, minimalMhtml);
            }

            using (System.IO.Stream inputStream = System.IO.File.OpenRead(inputPath))
            {
                byte[] docxBytes = ConvertMhtmlToDocxBytes(inputStream);
                string outputPath = "output.docx";
                System.IO.File.WriteAllBytes(outputPath, docxBytes);
                System.Console.WriteLine("DOCX file saved to: " + System.IO.Path.GetFullPath(outputPath));
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static byte[] ConvertMhtmlToDocxBytes(System.IO.Stream inputStream)
    {
        string tempDocxPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.Guid.NewGuid().ToString() + ".docx");
        Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempDocxPath);
        byte[] result = System.IO.File.ReadAllBytes(tempDocxPath);
        try { System.IO.File.Delete(tempDocxPath); } catch { }
        return result;
    }
}