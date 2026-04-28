// Find all form elements, list their input field names and default values for analysis.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Forms;

namespace FormFieldExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the HTML file to be analyzed
                string htmlPath = "sample.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Iterate over all forms in the document
                for (int formIndex = 0; formIndex < document.Forms.Length; formIndex++)
                {
                    // Get the current form element
                    HTMLFormElement form = (HTMLFormElement)document.Forms[formIndex];

                    // Iterate over all child elements of the form
                    for (int elemIndex = 0; elemIndex < form.Elements.Length; elemIndex++)
                    {
                        // Cast to generic Element to access attributes
                        Element element = (Element)form.Elements[elemIndex];
                        string tagName = element.TagName.ToLower();

                        // Process only input-like controls
                        if (tagName == "input" || tagName == "textarea" || tagName == "select")
                        {
                            // Retrieve the name attribute (field identifier)
                            string fieldName = element.GetAttribute("name");

                            // Retrieve the default value (value attribute for inputs, textContent for textarea)
                            string defaultValue = element.GetAttribute("value");

                            // For textarea, the default value may be the inner text
                            if (tagName == "textarea")
                            {
                                defaultValue = element.TextContent;
                            }

                            Console.WriteLine($"Form {formIndex}, Element <{tagName}> - Name: \"{fieldName}\", Default Value: \"{defaultValue}\"");
                        }
                    }
                }

                // Dispose the document to release resources
                document.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}