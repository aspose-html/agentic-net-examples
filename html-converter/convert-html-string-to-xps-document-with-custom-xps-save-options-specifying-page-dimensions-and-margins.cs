// Convert an HTML string to an XPS document using custom XpsSaveOptions that specify page dimensions and margins.

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
                string htmlContent = "<html><body><h1>Hello, XPS!</h1></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.BackgroundColor = System.Drawing.Color.White;

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.3f),
                        Aspose.Html.Drawing.Length.FromInches(5.8f)),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));
                options.PageSetup.AnyPage = page;

                string outputPath = "output.xps";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed successfully. Output: " + Path.GetFullPath(outputPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}