// Create a document, add a link element referencing a stylesheet, and ensure stylesheet loads on render.

using System;
using System.Linq;

namespace AsposeHtmlLinkExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create an empty HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

                // Create a <link> element for a stylesheet
                Aspose.Html.Dom.Element link = document.CreateElement("link");
                link.SetAttribute("rel", "stylesheet");
                link.SetAttribute("href", "https://example.com/style.css");

                // Get the <head> element and append the link
                Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
                head.AppendChild(link);

                // Save the document to a file
                document.Save("output.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}