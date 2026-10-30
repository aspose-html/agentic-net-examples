// Load an HTML document, replace inline styles with external stylesheet references, and save the updated file.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";
            string cssPath = "styles.css";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body style=\"background-color:#e5f3fd;\"><p style=\"color:red;\">Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Create a simple external stylesheet
            string cssContent = "body { background-color: #e5f3fd; }\np { color: red; }";
            File.WriteAllText(cssPath, cssContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the <head> element
            Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)document.GetElementsByTagName("head").First();

            // Create a <link> element referencing the external stylesheet
            Aspose.Html.Dom.Element link = document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", cssPath);
            head.AppendChild(link);

            // Remove all inline style attributes
            Aspose.Html.Collections.NodeList styledElements = document.QuerySelectorAll("[style]");
            foreach (Aspose.Html.Dom.Node node in styledElements)
            {
                Aspose.Html.Dom.Element element = node as Aspose.Html.Dom.Element;
                if (element != null)
                {
                    element.RemoveAttribute("style");
                }
            }

            // Save the updated HTML document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}