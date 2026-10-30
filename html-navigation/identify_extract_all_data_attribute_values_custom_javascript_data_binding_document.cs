// Identify and extract all data‑attribute values for custom JavaScript data binding in the document.

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
            // Prepare sample HTML file
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <div id='item1' data-id='123' data-name='ItemOne'>Content 1</div>
    <span data-info='InfoValue'>Content 2</span>
    <p>No data attribute here</p>
    <section data-section='SectionA' data-value='42'></section>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all elements in the document
            HTMLCollection allElements = document.GetElementsByTagName("*");

            // Iterate over each element and extract data- attributes
            for (int i = 0; i < allElements.Length; i++)
            {
                Element element = (Element)allElements[i];
                // Retrieve all attribute names of the element
                string[] attributeNames = element.GetAttributeNames();
                foreach (string attrName in attributeNames)
                {
                    if (attrName.StartsWith("data-"))
                    {
                        string attrValue = element.GetAttribute(attrName);
                        if (!string.IsNullOrEmpty(attrValue))
                        {
                            Console.WriteLine($"{attrName} = {attrValue}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}