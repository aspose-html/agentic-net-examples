// Create a new HTML document, set its language attribute to French, and save as UTF-8 HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Set the language attribute of the <html> element to French ("fr")
            document.DocumentElement.SetAttribute("lang", "fr");

            // Save the document as an HTML file (UTF-8 encoding is used by default)
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}