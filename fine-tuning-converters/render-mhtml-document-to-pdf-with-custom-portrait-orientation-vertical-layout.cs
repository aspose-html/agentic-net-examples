// Render an MHTML document to PDF with a custom page orientation set to Portrait for vertical layout.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.mhtml";
            string resultPath = "output.pdf";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string mhtmlContent = @"From: <Saved by Aspose.HTML>
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""

<html><body><h1>Hello MHTML</h1></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(sourcePath, mhtmlContent);
            }

            // Configure PDF rendering options with portrait orientation
            PdfSaveOptions options = new PdfSaveOptions();
            options.PageSetup.AnyPage = new Page(
                new Size(
                    Length.FromInches(8.27),   // Width
                    Length.FromInches(11.69)   // Height
                )
            );

            // Convert MHTML to PDF
            Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, resultPath);

            Console.WriteLine("MHTML has been successfully rendered to PDF at: " + Path.GetFullPath(resultPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}