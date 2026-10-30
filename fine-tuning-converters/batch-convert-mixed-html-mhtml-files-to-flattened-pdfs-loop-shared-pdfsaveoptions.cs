// Batch convert mixed HTML and MHTML files to flattened PDFs using a loop with shared PdfSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputFiles";
            string outputFolder = "OutputFiles";
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            string htmlPath = System.IO.Path.Combine(inputFolder, "sample.html");
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello HTML</h1></body></html>");
            }

            string mhtmlPath = System.IO.Path.Combine(inputFolder, "sample.mhtml");
            if (!System.IO.File.Exists(mhtmlPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\nSubject: sample\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><h1>Hello MHTML</h1></body></html>\r\n------=_NextPart_000_0000--";
                System.IO.File.WriteAllText(mhtmlPath, mhtmlContent);
            }

            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            string[] files = System.IO.Directory.GetFiles(inputFolder);
            foreach (string file in files)
            {
                string ext = System.IO.Path.GetExtension(file).ToLowerInvariant();
                string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(file) + ".pdf");
                if (ext == ".mhtml")
                {
                    using (System.IO.Stream stream = System.IO.File.OpenRead(file))
                    {
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                    }
                }
                else
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(file))
                    {
                        Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);
                    }
                }
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}