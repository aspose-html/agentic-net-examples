// Use ConvertHTML with XpsRenderingOptions to produce XPS files from HTML while applying custom bottom margin.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string documentPath = "sample.html";
            string savePath = "output.xps";

            if (!System.IO.File.Exists(documentPath))
            {
                System.IO.File.WriteAllText(documentPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            options.BackgroundColor = System.Drawing.Color.White;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5f),
                    Aspose.Html.Drawing.Length.FromInches(11f)),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 1)); // left, top, right, bottom (in inches)

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("HTML successfully converted to XPS with custom bottom margin.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}