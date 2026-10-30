// Configure DocRenderingOptions to set page orientation to Landscape and apply 0.75‑inch margins on all sides.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file
            string htmlPath = "sample.html";
            System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, World!</h1></body></html>");

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure rendering options: landscape orientation with 0.75‑inch margins
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.75),
                Aspose.Html.Drawing.Length.FromInches(0.75),
                Aspose.Html.Drawing.Length.FromInches(0.75),
                Aspose.Html.Drawing.Length.FromInches(0.75));

            // Landscape A4 size (width > height)
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(842, 595);

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            // Render to DOCX
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, "output.docx");
            document.RenderTo(device);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}