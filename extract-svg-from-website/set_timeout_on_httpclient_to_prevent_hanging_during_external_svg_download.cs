// Set a timeout on HttpClient to prevent hanging during external SVG download.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL of the HTML page containing external SVGs
            string url = "https://example.com/sample.html";

            // Create a request with a timeout to avoid hanging
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(10);

            // Load the HTML document using the request
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request);

            // Get all SVG elements in the document
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            for (int i = 0; i < svgs.Length; i++)
            {
                // Extract the outer HTML of the SVG element
                string svgHtml = ((Aspose.Html.HTMLElement)svgs[i]).OuterHTML;

                // Save the SVG markup to a temporary file
                string tempSvgPath = $"svg_{i}.svg";
                System.IO.File.WriteAllText(tempSvgPath, svgHtml);

                // Load the saved SVG as an SVGDocument
                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(tempSvgPath);

                // Define save options (default options)
                Aspose.Html.Dom.Svg.Saving.SVGSaveOptions options = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();

                // Save the SVG document (could be converted to another format if needed)
                string outputSvgPath = $"svg_{i}_saved.svg";
                svgDoc.Save(outputSvgPath, options);
            }

            // Clean up
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}