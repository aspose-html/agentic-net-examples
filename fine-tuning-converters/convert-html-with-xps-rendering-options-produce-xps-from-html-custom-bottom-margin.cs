// Use ConvertHTML with XpsRenderingOptions to produce XPS files from HTML while applying custom bottom margin.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "sample.html";
            string savePath = "output.xps";

            if (!System.IO.File.Exists(documentPath))
            {
                System.IO.File.WriteAllText(documentPath, "<!DOCTYPE html><html><body><h1>Hello, XPS!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.White;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 50));

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}