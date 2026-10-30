// Implement error handling that catches conversion exceptions and logs source file path for failed MHTML.

using System;

class Program
{
    static void Main()
    {
        string sourcePath = "sample.mhtml";
        string outputPath = "output.doc";

        try
        {
            // Create a minimal MHTML file if it does not exist
            if (!System.IO.File.Exists(sourcePath))
            {
                string minimalMhtml = "From: <Saved by WebKit>\r\nSubject: Test\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><p>Hello World</p></body></html>\r\n------=_NextPart_000_0000--";
                System.IO.File.WriteAllText(sourcePath, minimalMhtml);
            }

            using (System.IO.FileStream stream = System.IO.File.OpenRead(sourcePath))
            {
                Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
            }

            System.Console.WriteLine("Conversion succeeded. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error converting MHTML file: " + sourcePath);
            System.Console.WriteLine("Exception: " + ex.Message);
        }
    }
}