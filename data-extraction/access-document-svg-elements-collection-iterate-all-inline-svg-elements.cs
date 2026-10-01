// Access the document's SVG elements collection to iterate over all inline <svg> elements.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with inline SVG elements
            string htmlContent = @"
                <html>
                    <body>
                        <svg width='100' height='100' xmlns='http://www.w3.org/2000/svg'>
                            <circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' />
                        </svg>
                        <svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
                            <rect width='150' height='150' x='25' y='25' stroke='blue' stroke-width='5' fill='red' />
                        </svg>
                    </body>
                </html>";

            // Load the HTML document from the inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all inline <svg> elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Iterate over each SVG element and save it as a separate file
            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;
                string fileName = $"svg_{i}.svg";

                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "about:blank");
                svgDoc.Save(fileName);
            }

            Console.WriteLine("SVG extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}