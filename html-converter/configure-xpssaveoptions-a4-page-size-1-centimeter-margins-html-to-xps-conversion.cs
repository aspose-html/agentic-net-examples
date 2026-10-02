// Configure XpsSaveOptions to use A4 page size and 1‑centimeter margins for HTML to XPS conversion.

using System;
using System.IO;
using System.Drawing;

namespace HTMLToXpsExample
{
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
                    File.WriteAllText(documentPath, "<html><body><h1>Hello World</h1></body></html>");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.BackgroundColor = System.Drawing.Color.White;
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.27f),
                        Aspose.Html.Drawing.Length.FromInches(11.69f)),
                    new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromInches(0.3937f),
                        Aspose.Html.Drawing.Length.FromInches(0.3937f),
                        Aspose.Html.Drawing.Length.FromInches(0.3937f),
                        Aspose.Html.Drawing.Length.FromInches(0.3937f)));

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}