// Load an HTML file, replace all <b> tags with <strong> tags, and save the updated file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><p>This is <b>bold</b> and another <b>example</b>.</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all <b> elements
            HTMLCollection bElements = document.GetElementsByTagName("b");

            // Replace each <b> with <strong>
            for (int i = bElements.Length - 1; i >= 0; i--)
            {
                Element bElement = (Element)bElements[i];
                // Create a new <strong> element
                HTMLElement strongElement = (HTMLElement)document.CreateElement("strong");
                // Copy inner HTML/content
                strongElement.InnerHTML = ((HTMLElement)bElement).InnerHTML;
                // Replace the old <b> element with the new <strong> element
                Node parent = bElement.ParentNode;
                parent.ReplaceChild(strongElement, bElement);
            }

            // Save the updated document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}