// Extract CSRF token hidden input values from forms for security testing purposes.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file that contains the forms
            string htmlPath = "sample.html";

            // Load the HTML document from the file system
            // Rule: Aspose.Html.HTMLDocument {document} = new Aspose.Html.HTMLDocument({string_literal});
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Select all hidden input elements that are likely to hold CSRF tokens
            // Adjust the selector if your token field uses a different name
            var hiddenInputs = document.QuerySelectorAll("input[type=hidden][name='csrf_token']");

            // Iterate through the selected inputs and print their values
            foreach (var node in hiddenInputs)
            {
                // Cast the node to a generic Element to access attributes
                if (node is Element element)
                {
                    string tokenValue = element.GetAttribute("value");
                    Console.WriteLine($"CSRF token found: {tokenValue}");
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