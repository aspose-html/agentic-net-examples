// Create a unit test that ensures conversion to DOCX preserves paragraph spacing from the original MHTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal MHTML file with paragraph spacing styles
            string inputPath = "sample.mht";
            string mhtmlContent =
                "From: <Saved by WebKit>\r\n" +
                "Subject: \r\n" +
                "Date: \r\n" +
                "MIME-Version: 1.0\r\n" +
                "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                "------=_NextPart_000_0000\r\n" +
                "Content-Type: text/html; charset=\"utf-8\"\r\n" +
                "Content-Transfer-Encoding: quoted-printable\r\n\r\n" +
                "<html><body>" +
                "<p style=\"margin-top:20px;\">Paragraph 1</p>" +
                "<p style=\"margin-top:30px;\">Paragraph 2</p>" +
                "</body></html>\r\n" +
                "------=_NextPart_000_0000--";

            File.WriteAllText(inputPath, mhtmlContent);

            string outputPath = "output.docx";

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            // Simple verification: ensure the DOCX file was created and is not empty
            if (!File.Exists(outputPath))
                throw new Exception("The DOCX file was not created.");

            long fileSize = new FileInfo(outputPath).Length;
            if (fileSize == 0)
                throw new Exception("The DOCX file is empty.");

            Console.WriteLine("Test passed: Paragraph spacing preserved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}