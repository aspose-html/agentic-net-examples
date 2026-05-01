// Create an HTML document from an SVG file, add descriptive text, and export it to MHTML.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

namespace AsposeHtmlMhtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source SVG file
                string svgPath = "input.svg";

                // Read SVG markup from the file
                string svgContent = File.ReadAllText(svgPath);

                // Build HTML content that includes descriptive text and the SVG markup
                string htmlContent = $"<html><body><p>This is a description of the SVG image.</p>{svgContent}</body></html>";

                // Base URI required for the HTMLDocument constructor
                Url baseUri = new Url("file:///");

                // Create an HTML document from the HTML string
                HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

                // Save the document as MHTML
                MHTMLSaveOptions mhtmlOptions = new MHTMLSaveOptions();
                document.Save("output.mhtml", mhtmlOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}