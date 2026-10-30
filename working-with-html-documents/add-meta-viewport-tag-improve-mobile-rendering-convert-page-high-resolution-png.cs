// Add a meta viewport tag to improve mobile rendering, then convert the page to a high‑resolution PNG.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                // Add meta viewport tag
                Aspose.Html.Dom.Element meta = document.CreateElement("meta");
                meta.SetAttribute("name", "viewport");
                meta.SetAttribute("content", "width=device-width, initial-scale=1.0");

                Aspose.Html.Collections.HTMLCollection heads = document.GetElementsByTagName("head");
                if (heads.Length > 0)
                {
                    Aspose.Html.Dom.Element head = heads[0] as Aspose.Html.Dom.Element;
                    head.AppendChild(meta);
                }

                // Render to high‑resolution PNG
                Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                string outputPath = "output.png";
                Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
                document.RenderTo(device);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}