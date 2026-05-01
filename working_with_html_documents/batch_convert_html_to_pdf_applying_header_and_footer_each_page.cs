// Batch convert HTML to PDF, applying a header and footer on each page of the output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                string fileName = Path.GetFileNameWithoutExtension(htmlPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(Aspose.Html.Drawing.Length.FromInches(8.5f), Aspose.Html.Drawing.Length.FromInches(11f));
                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(50, 50, 50, 50);
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
                options.PageSetup.AnyPage = page;
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}