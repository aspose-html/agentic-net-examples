// Configure DocRenderingOptions to set page orientation to Landscape and apply 0.75‑inch margins on all sides.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string docPath = "output.doc";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.75),
                Aspose.Html.Drawing.Length.FromInches(0.75),
                Aspose.Html.Drawing.Length.FromInches(0.75),
                Aspose.Html.Drawing.Length.FromInches(0.75));

            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(842, 595);

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);

            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, docPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}