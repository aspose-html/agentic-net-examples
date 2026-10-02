// Set PDF page margins using PdfSaveOptions.MarginTop, MarginBottom, MarginLeft, and MarginRight before conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.5),
                Aspose.Html.Drawing.Length.FromInches(0.5),
                Aspose.Html.Drawing.Length.FromInches(0.5),
                Aspose.Html.Drawing.Length.FromInches(0.5));

            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            Console.WriteLine("PDF conversion completed. Output: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}