// Insert checklist items using task list syntax and set their initial checked state.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML template with a checkbox
            string htmlTemplate = "<!DOCTYPE html><html><body><ul><li><input type=\"checkbox\" id=\"taskItem\"/> Sample Task</li></ul></body></html>";
            bool isChecked = true;
            string outputPath = "output.html";

            // Load the HTML content
            Aspose.Html.HTMLDocument templateDocument = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            // Find the first input element (checkbox) and set its checked state
            Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)templateDocument.GetElementsByTagName("input")[0];
            input.Checked = isChecked;

            // Save the modified document
            templateDocument.Save(outputPath);

            Console.WriteLine("HTML document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}