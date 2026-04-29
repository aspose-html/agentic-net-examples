// Validate that ordered list numbers are sequential and correct any gaps after item removal.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace OrderedListValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the source and destination HTML files
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Retrieve all <ol> elements in the document
                HTMLCollection orderedLists = document.GetElementsByTagName("ol");

                // Process each ordered list
                for (int i = 0; i < orderedLists.Length; i++)
                {
                    // Cast the collection item to an Element representing <ol>
                    Element ol = (Element)orderedLists[i];

                    // Get all <li> elements within this <ol>
                    HTMLCollection listItems = ol.GetElementsByTagName("li");

                    // Renumber the list items sequentially
                    for (int j = 0; j < listItems.Length; j++)
                    {
                        Element li = (Element)listItems[j];
                        // Set the 'value' attribute to the correct number (starting from 1)
                        li.SetAttribute("value", (j + 1).ToString());
                    }
                }

                // Save the updated HTML document
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}