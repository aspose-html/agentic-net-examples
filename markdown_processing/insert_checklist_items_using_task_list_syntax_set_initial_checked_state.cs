// Insert checklist items using task list syntax and set their initial checked state.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace ChecklistExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new HTML document with a basic structure
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("<html><body></body></html>", "");

                // Get the body element to append content
                var body = document.Body;

                // Create an unordered list to hold checklist items
                var ul = document.CreateElement("ul");
                body.AppendChild(ul);

                // Define checklist items and their initial checked state
                var items = new (string Text, bool IsChecked)[]
                {
                    ("Buy groceries", false),
                    ("Call Alice", true),
                    ("Finish report", false)
                };

                // Insert each checklist item as a list element with a checkbox input
                foreach (var (text, isChecked) in items)
                {
                    // Create list item
                    var li = document.CreateElement("li");

                    // Create checkbox input
                    var input = (Aspose.Html.HTMLInputElement)document.CreateElement("input");
                    input.SetAttribute("type", "checkbox");
                    input.Checked = isChecked; // Set initial checked state

                    // Append checkbox and text to list item
                    li.AppendChild(input);
                    li.AppendChild(document.CreateTextNode(" " + text));

                    // Append list item to the unordered list
                    ul.AppendChild(li);
                }

                // Save the resulting HTML to a file
                document.Save("checklist.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}