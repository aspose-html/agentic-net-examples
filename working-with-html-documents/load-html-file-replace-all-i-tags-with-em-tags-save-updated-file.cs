// Load an HTML file, replace all <i> tags with <em> tags, and save the updated file.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><p>Hello <i>world</i>! This is <i>sample</i> text.</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document from file
            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Collect all <i> elements
                var iElementsCollection = document.GetElementsByTagName("i");
                var iElements = new List<Aspose.Html.Dom.Element>();
                foreach (Aspose.Html.Dom.Element elem in iElementsCollection)
                {
                    iElements.Add(elem);
                }

                // Replace each <i> with <em>
                foreach (Aspose.Html.Dom.Element iElem in iElements)
                {
                    var iHtmlElem = iElem as Aspose.Html.HTMLElement;
                    if (iHtmlElem != null)
                    {
                        var emElem = (Aspose.Html.HTMLElement)document.CreateElement("em");
                        emElem.InnerHTML = iHtmlElem.InnerHTML;

                        Aspose.Html.Dom.Node parent = iElem.ParentNode;
                        if (parent != null)
                        {
                            parent.ReplaceChild(emElem, iElem);
                        }
                    }
                }

                // Save the updated document
                document.Save(outputPath);
            }

            Console.WriteLine("HTML file processed and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}