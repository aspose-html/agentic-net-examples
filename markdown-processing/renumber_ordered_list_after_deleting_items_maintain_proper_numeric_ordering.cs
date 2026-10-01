// Renumber an ordered list after deleting items to maintain proper numeric ordering.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

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
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<ol>
<li>Item 1</li>
<li>Item 2</li>
<li>Item 3</li>
<li>Item 4</li>
</ol>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Get the first ordered list (<ol>)
                Aspose.Html.Collections.HTMLCollection olCollection = document.GetElementsByTagName("ol");
                if (olCollection.Length > 0)
                {
                    Aspose.Html.Dom.Element ol = (Aspose.Html.Dom.Element)olCollection[0];

                    // Identify <li> elements to remove (e.g., 2nd and 4th items)
                    List<Aspose.Html.Dom.Element> itemsToRemove = new List<Aspose.Html.Dom.Element>();
                    Aspose.Html.Dom.Node child = ol.FirstChild;
                    int position = 0;
                    while (child != null)
                    {
                        if (child.NodeName == "li")
                        {
                            position++;
                            if (position == 2 || position == 4)
                            {
                                itemsToRemove.Add((Aspose.Html.Dom.Element)child);
                            }
                        }
                        child = child.NextSibling;
                    }

                    // Remove the selected items
                    foreach (Aspose.Html.Dom.Element li in itemsToRemove)
                    {
                        ol.RemoveChild(li);
                    }

                    // Renumber remaining <li> elements by setting the "value" attribute
                    child = ol.FirstChild;
                    int newNumber = 1;
                    while (child != null)
                    {
                        if (child.NodeName == "li")
                        {
                            ((Aspose.Html.Dom.Element)child).SetAttribute("value", newNumber.ToString());
                            newNumber++;
                        }
                        child = child.NextSibling;
                    }
                }

                // Save the modified document
                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}