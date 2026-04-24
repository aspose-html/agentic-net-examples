// Enable text rasterization in XpsSaveOptions to improve rendering quality of HTML to XPS output.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToXpsExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                string xpsPath = "output.xps";

                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    XpsSaveOptions options = new XpsSaveOptions();
                    Converter.ConvertHTML(document, options, xpsPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}