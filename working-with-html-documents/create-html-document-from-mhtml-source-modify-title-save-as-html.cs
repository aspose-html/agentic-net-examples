// Create an HTML document from an MHTML source, modify its title, and save as HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mht";
            string outputPath = "output.html";

            if (!File.Exists(sourcePath))
            {
                string mhtmlContent =
                    "From: <Saved by WebKit>\r\n" +
                    "Subject: Sample MHTML\r\n" +
                    "MIME-Version: 1.0\r\n" +
                    "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                    "------=_NextPart_000_0000\r\n" +
                    "Content-Type: text/html; charset=\"utf-8\"\r\n" +
                    "Content-Transfer-Encoding: quoted-printable\r\n\r\n" +
                    "<html><head><title>Original Title</title></head><body><p>Hello World</p></body></html>\r\n" +
                    "------=_NextPart_000_0000--";

                File.WriteAllText(sourcePath, mhtmlContent);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath))
            {
                document.Title = "Modified Title";
                document.Save(outputPath, Aspose.Html.Saving.HTMLSaveFormat.Original);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}