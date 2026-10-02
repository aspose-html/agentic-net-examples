// Render an HTML document to XPS with landscape orientation by setting XpsRenderingOptions.PageOrientation.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Rendering.Xps;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, XPS Landscape!</h1></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Rendering.Xps.XpsRenderingOptions options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
            options.BackgroundColor = System.Drawing.Color.White;

            Aspose.Html.Drawing.Page anyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11),
                    Aspose.Html.Drawing.Length.FromInches(8.5)
                )
            );
            options.PageSetup.AnyPage = anyPage;

            string outputPath = "output_landscape.xps";
            Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}