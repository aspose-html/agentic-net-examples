// Validate that the document does not contain any raw HTML tags to ensure strict Markdown compliance.

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
            // Sample HTML content to validate
            string htmlContent = "<p>Hello, world!</p><custom>Raw HTML tag</custom>";

            // Load the HTML content into an Aspose.HTML document
            HTMLDocument document = new HTMLDocument(htmlContent, "");

            // Retrieve all elements in the document (using wildcard tag name)
            HTMLCollection elements = document.GetElementsByTagName("*");

            // Iterate through each element and output its tag name
            for (int i = 0; i < elements.Length; i++)
            {
                Element element = (Element)elements[i];
                Console.WriteLine(element.TagName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}