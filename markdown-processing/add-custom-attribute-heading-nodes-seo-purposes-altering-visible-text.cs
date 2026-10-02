// Add a custom attribute to heading nodes for SEO purposes without altering visible text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create a new empty HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = doc.Body;

            // Create an H1 heading element
            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
            // Add a custom SEO attribute without changing visible text
            h1.SetAttribute("data-seo", "important");
            // Append visible text to the heading
            h1.AppendChild(doc.CreateTextNode("Welcome to Aspose.HTML"));
            // Add the heading to the document body
            body.AppendChild(h1);

            // Save the document to a file
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}