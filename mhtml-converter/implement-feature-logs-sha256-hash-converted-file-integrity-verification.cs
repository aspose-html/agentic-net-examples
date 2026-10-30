// Implement a feature that logs the SHA‑256 hash of the converted file for integrity verification.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPath = "output.docx";

                if (!System.IO.File.Exists(inputPath))
                {
                    string mhtmlContent = "From: <Saved by WebKit>\nSubject: Sample MHTML\nDate: Thu, 1 Jan 1970 00:00:00 GMT\nMIME-Version: 1.0\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\nContent-Transfer-Encoding: quoted-printable\n\n<html><body><h1>Hello World</h1></body></html>\n------=_NextPart_000_0000--";
                    System.IO.File.WriteAllText(inputPath, mhtmlContent);
                }

                System.IO.Stream inputStream = System.IO.File.OpenRead(inputPath);
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
                inputStream.Close();

                byte[] outputBytes = System.IO.File.ReadAllBytes(outputPath);
                using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(outputBytes);
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(hashBytes.Length * 2);
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    string hashString = sb.ToString();
                    System.Console.WriteLine("Output file: " + outputPath);
                    System.Console.WriteLine("SHA-256 hash: " + hashString);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}