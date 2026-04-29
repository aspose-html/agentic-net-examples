// Load an SVG document from a stream using a MemoryStream.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'></svg>";
            byte[] svgBytes = Encoding.UTF8.GetBytes(svgContent);
            using (MemoryStream memoryStream = new MemoryStream(svgBytes))
            {
                // Load SVG document from the memory stream
                using (SVGDocument svgDocument = new SVGDocument(memoryStream, "http://example.com/"))
                {
                    // Document loaded successfully; you can work with svgDocument here
                    Console.WriteLine("SVG document loaded. Root element: " + svgDocument.RootElement.TagName);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}