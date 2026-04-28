// Detect the language attribute of the HTML tag and set it to “en‑US” if missing.

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
            // Paths to the input and output HTML files
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(inputPath);

            // Retrieve the <html> element
            HTMLCollection htmlElements = document.GetElementsByTagName("html");
            if (htmlElements.Length > 0)
            {
                Element htmlElement = (Element)htmlElements[0];

                // Check the existing lang attribute
                string lang = htmlElement.GetAttribute("lang");
                if (string.IsNullOrWhiteSpace(lang))
                {
                    // Set the language attribute to "en-US" if it is missing or empty
                    htmlElement.SetAttribute("lang", "en-US");
                }
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