// Output the src attribute values of the image nodes collected via XPath.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file with images
            string htmlContent = @"
                <html>
                    <body>
                        <img src='image1.png' />
                        <div>
                            <img src='image2.jpg' class='photo' />
                        </div>
                        <img src='image3.gif' />
                    </body>
                </html>";
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath);

            // Evaluate XPath to select all img elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                "//img",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            // Iterate over the selected nodes and output the src attribute
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                Console.WriteLine(img.Src);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}