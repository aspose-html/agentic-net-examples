// Create a unit test that ensures conversion to DOCX preserves paragraph spacing from the original MHTML.

using System;
using System.IO;
using System.IO.Compression;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML content with paragraph spacing
            string mhtmlPath = "sample.mht";
            string docxPath = "output.docx";

            string mhtmlContent = @"From: <Saved by WebKit>
Subject: 
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><p style=""margin-top:20px; margin-bottom:10px;"">Test paragraph</p></body></html>

------=_NextPart_000_0000--";

            File.WriteAllText(mhtmlPath, mhtmlContent, Encoding.UTF8);

            // Convert MHTML to DOCX
            using (Stream inputStream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, saveOptions, docxPath);
            }

            // Verify that the resulting DOCX contains paragraph spacing information
            using (FileStream zipToOpen = new FileStream(docxPath, FileMode.Open, FileAccess.Read))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
            {
                ZipArchiveEntry documentXmlEntry = archive.GetEntry("word/document.xml");
                if (documentXmlEntry == null)
                    throw new Exception("document.xml not found in the DOCX package.");

                string documentXml;
                using (StreamReader reader = new StreamReader(documentXmlEntry.Open(), Encoding.UTF8))
                {
                    documentXml = reader.ReadToEnd();
                }

                if (!documentXml.Contains("<w:spacing"))
                    throw new Exception("Paragraph spacing information was not preserved in the DOCX output.");
            }

            Console.WriteLine("Test passed: Paragraph spacing preserved after MHTML to DOCX conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}