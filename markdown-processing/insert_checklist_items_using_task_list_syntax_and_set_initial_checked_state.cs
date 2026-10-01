// Insert checklist items using task list syntax and set their initial checked state.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlTemplate = "<!DOCTYPE html><html><body><ul><li><input type=\"checkbox\" id=\"task1\"/> Task 1</li></ul></body></html>";
            bool isChecked = true;
            string outputPath = "output.html";

            // Load HTML from string
            Aspose.Html.HTMLDocument templateDocument = new Aspose.Html.HTMLDocument(htmlTemplate, "");

            // Find the input element by id
            Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)templateDocument.GetElementById("task1");
            if (input != null)
            {
                input.Checked = isChecked;
            }

            // Save the modified document
            templateDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}