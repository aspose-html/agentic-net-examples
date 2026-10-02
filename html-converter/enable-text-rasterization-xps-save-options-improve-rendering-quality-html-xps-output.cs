// Enable text rasterization in XpsSaveOptions to improve rendering quality of HTML to XPS output.

using System;

namespace AsposeHtmlXpsExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample HTML to XPS conversion.</p></body></html>";
                Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.White;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.xps");
                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}