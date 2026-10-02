// Save the resulting HTMLDocument as a PDF file by providing PdfSaveOptions to ConvertHTML.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string savePath = "output.pdf";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<!DOCTYPE html><html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("PDF saved to " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}