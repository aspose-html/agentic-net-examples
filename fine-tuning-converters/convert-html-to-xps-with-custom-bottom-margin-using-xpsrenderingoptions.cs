// Use ConvertHTML with XpsRenderingOptions to produce XPS files from HTML while applying custom bottom margin.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "sample.html";
            string savePath = "output.xps";

            if (!File.Exists(documentPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(documentPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            options.BackgroundColor = System.Drawing.Color.White;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 50) // left, top, right, bottom margin
            );

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully. XPS saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}