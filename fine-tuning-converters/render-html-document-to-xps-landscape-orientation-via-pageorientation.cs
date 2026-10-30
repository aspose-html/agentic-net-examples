// Render an HTML document to XPS with landscape orientation by setting XpsRenderingOptions.PageOrientation.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create an HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("<html><body><h1>Hello XPS</h1></body></html>", "about:blank");

            // Configure XPS rendering options with landscape page size
            Aspose.Html.Rendering.Xps.XpsRenderingOptions options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
            Aspose.Html.Drawing.Page landscapePage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11), // width (landscape)
                    Aspose.Html.Drawing.Length.FromInches(8.5) // height
                ),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0)
            );
            options.PageSetup.AnyPage = landscapePage;

            // Define output XPS file path
            string savePath = "output.xps";

            // Render the document to XPS
            Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(options, savePath);
            document.RenderTo(device);

            Console.WriteLine("HTML has been successfully rendered to XPS at: " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}