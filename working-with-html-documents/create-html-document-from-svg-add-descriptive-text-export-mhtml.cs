// Create an HTML document from an SVG file, add descriptive text, and export it to MHTML.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define SVG content
            string svgContent = "<svg width=\"200\" height=\"200\" xmlns=\"http://www.w3.org/2000/svg\"><circle cx=\"100\" cy=\"100\" r=\"80\" fill=\"lightblue\" stroke=\"navy\" stroke-width=\"4\"/></svg>";
            // Save SVG to a temporary file (optional, demonstrates file creation)
            string tempSvgPath = "sample.svg";
            File.WriteAllText(tempSvgPath, svgContent);

            // Create HTML that includes the SVG markup and descriptive text
            string htmlContent = $"<html><body><h1>SVG Example</h1>{svgContent}<p>This is a description of the SVG image.</p></body></html>";

            // Base URI required for inline HTML content
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");

            // Load HTML document from the string content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Export the document to MHTML
            string outputPath = "output.mhtml";
            Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
            document.Save(outputPath, mhtmlOptions);

            Console.WriteLine("MHTML file created successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}