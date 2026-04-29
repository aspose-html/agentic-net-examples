// Toggle the checked state of task list items programmatically to reflect completion status.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            HTMLDocument document = new HTMLDocument();

            // Sample HTML containing task list items
            string htmlContent = @"<!DOCTYPE html>
<html>
<body>
<ul>
<li><input type=""checkbox"" checked> Task 1</li>
<li><input type=""checkbox""> Task 2</li>
<li><input type=""checkbox"" checked> Task 3</li>
</ul>
</body>
</html>";

            // Load the HTML content into the document
            document.Write(htmlContent);

            // Find all checkbox inputs representing task list items
            var checkboxes = document.QuerySelectorAll("input[type=checkbox]");

            // Toggle the checked state of each checkbox
            foreach (Node node in checkboxes)
            {
                if (node is Element element)
                {
                    if (element.HasAttribute("checked"))
                        element.RemoveAttribute("checked");
                    else
                        element.SetAttribute("checked", "checked");
                }
            }

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}