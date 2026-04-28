// Remove all script tags from the DOM to eliminate executable JavaScript before saving.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source and destination HTML files
            string sourcePath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document from the source file
            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                // Retrieve all <script> elements in the document
                HTMLCollection scriptElements = document.GetElementsByTagName("script");

                // Remove each script element from its parent node
                foreach (Element script in scriptElements.ToList())
                {
                    script.ParentNode.RemoveChild(script);
                }

                // Save the cleaned document to the output file
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}