// Detect and correct malformed tags such as missing closing brackets during parsing.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML with a missing closing tag
            string htmlContent = "<html><body><p>Sample paragraph</body></html>";

            // Load HTML content using the two-argument constructor (inline content)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Retrieve the corrected HTML after parsing
            Element rootElement = document.DocumentElement;
            string correctedHtml = rootElement.OuterHTML;

            Console.WriteLine("Original HTML:");
            Console.WriteLine(htmlContent);
            Console.WriteLine();
            Console.WriteLine("Corrected HTML after parsing:");
            Console.WriteLine(correctedHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}