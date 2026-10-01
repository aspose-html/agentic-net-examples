// Replace all occurrences of non‑breaking space characters with regular spaces for text normalization.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content containing non‑breaking space characters (U+00A0)
            string htmlContent = "Hello\u00A0World! This\u00A0is\u00A0a\u00A0test.";

            // Load the HTML content into an Aspose.Html.HTMLDocument
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Cast the body element to HTMLElement to access InnerHTML
            Aspose.Html.HTMLElement bodyElement = (Aspose.Html.HTMLElement)document.Body;

            // Get the HTML of the body and replace non‑breaking spaces with regular spaces
            string normalizedHtml = bodyElement.InnerHTML.Replace('\u00A0', ' ');

            // Output the normalized HTML
            Console.WriteLine("Normalized HTML:");
            Console.WriteLine(normalizedHtml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred: " + ex.Message);
        }
    }
}