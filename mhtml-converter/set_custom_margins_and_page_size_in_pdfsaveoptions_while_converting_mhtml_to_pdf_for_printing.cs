// Set custom margins and page size in PdfSaveOptions while converting MHTML to PDF for printing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string mhtmlPath = "sample.mht";
            string pdfPath = "output.pdf";

            if (!File.Exists(mhtmlPath))
            {
                string simpleHtml = "<html><body><h1>Hello MHTML</h1></body></html>";
                File.WriteAllText(mhtmlPath, simpleHtml);
            }

            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11));

                Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromInches(1),
                    Aspose.Html.Drawing.Length.FromInches(1),
                    Aspose.Html.Drawing.Length.FromInches(1),
                    Aspose.Html.Drawing.Length.FromInches(1));

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
                pdfOptions.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, pdfPath);
            }

            Console.WriteLine("MHTML has been successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
