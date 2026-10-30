// Create an HTML document, add a form with input fields, and save as HTML for testing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test Form</title></head><body>" +
                                 "<form id='myForm'>" +
                                 "<input type='text' name='firstName' value='John' />" +
                                 "<input type='text' name='lastName' value='Doe' />" +
                                 "<input type='submit' value='Submit' />" +
                                 "</form>" +
                                 "</body></html>";

            // Load HTML content into a document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, string.Empty);

            // Optionally modify input values (example)
            Aspose.Html.Collections.HTMLCollection inputs = doc.GetElementsByTagName("input");
            if (inputs.Length > 0)
            {
                Aspose.Html.HTMLInputElement firstInput = (Aspose.Html.HTMLInputElement)inputs[0];
                firstInput.Value = "Alice";
            }

            // Save the document with input values serialized
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.SerializeInputValue = true;

            string outputPath = "output.html";
            doc.Save(outputPath, options);

            // Clean up
            doc.Dispose();

            Console.WriteLine($"HTML document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}