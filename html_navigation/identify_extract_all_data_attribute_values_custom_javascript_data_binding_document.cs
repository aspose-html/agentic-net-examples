// Identify and extract all data‑attribute values for custom JavaScript data binding in the document.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document (replace with your file path or URL)
            HTMLDocument document = new HTMLDocument("input.html");

            // Retrieve all elements in the document
            HTMLCollection elements = document.GetElementsByTagName("*");

            // Iterate through each element
            for (int i = 0; i < elements.Length; i++)
            {
                // Cast the node to an Element to access attribute methods
                Element element = (Element)elements[i];

                // Get all attribute names of the current element
                string[] attributeNames = element.GetAttributeNames();

                // Check each attribute for a "data-" prefix
                foreach (string attrName in attributeNames)
                {
                    if (attrName.StartsWith("data-"))
                    {
                        // Retrieve and output the value of the data attribute
                        string value = element.GetAttribute(attrName);
                        Console.WriteLine($"{attrName} = {value}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}