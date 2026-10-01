// Configure the parser to treat unknown tags as generic elements instead of throwing errors.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with an unknown tag
            string htmlContent = "<html><body><custom-tag>Test</custom-tag></body></html>";

            // Write HTML to a temporary file
            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            // Load the document from the temporary file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(new Aspose.Html.Url(tempFile));

            // Retrieve and print unknown tag elements
            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("custom-tag");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                System.Console.WriteLine(element.TagName);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}