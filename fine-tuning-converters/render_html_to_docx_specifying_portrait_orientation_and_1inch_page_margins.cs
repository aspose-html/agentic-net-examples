// Render HTML to DOCX with DocRenderingOptions specifying portrait orientation and 1‑inch page margins.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("<html><body><h1>Hello World</h1></body></html>");

            // Configure rendering options: portrait orientation with 1-inch margins
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromInches(1),
                    Aspose.Html.Drawing.Length.FromInches(1),
                    Aspose.Html.Drawing.Length.FromInches(1),
                    Aspose.Html.Drawing.Length.FromInches(1)));

            // Render the HTML to DOCX
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, "output.docx");
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}