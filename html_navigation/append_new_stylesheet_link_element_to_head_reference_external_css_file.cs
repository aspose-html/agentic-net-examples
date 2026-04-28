// Append a new stylesheet link element to the head to reference an external CSS file.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for the source HTML, the output HTML, and the external CSS file
            string inputPath = "input.html";
            string outputPath = "output.html";
            string cssPath = "styles.css";

            // Load the existing HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a <link> element that references the external stylesheet
            HTMLLinkElement link = (HTMLLinkElement)document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", cssPath);
            link.SetAttribute("type", "text/css");

            // Retrieve the <head> element
            HTMLElement head = (HTMLElement)document.GetElementsByTagName("head").First();

            // Append the <link> element to the <head>
            if (head != null)
            {
                head.AppendChild(link);
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}