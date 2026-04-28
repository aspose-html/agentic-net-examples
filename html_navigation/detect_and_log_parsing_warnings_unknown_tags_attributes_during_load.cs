// Detect and log any parsing warnings such as unknown tags or attributes during load.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content containing an unknown tag <custom-tag>
            string htmlContent = "<html><body><custom-tag attr='value'>Hello</custom-tag></body></html>";

            // Load the HTML document from the string (base URI is empty)
            HTMLDocument document = new HTMLDocument(htmlContent, "");

            // Retrieve all elements in the document
            HTMLCollection elements = document.GetElementsByTagName("*");

            // Iterate through elements and log their tag names
            for (int i = 0; i < elements.Length; i++)
            {
                Element element = (Element)elements[i];
                Console.WriteLine($"Tag: {element.TagName}");
            }
        }
        catch (Exception ex)
        {
            // Log any exceptions that occur during loading or processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}