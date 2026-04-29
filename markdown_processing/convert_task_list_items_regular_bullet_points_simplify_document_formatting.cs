// Convert task list items to regular bullet points to simplify document formatting.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(inputPath);

            var checkboxes = document.QuerySelectorAll("li input[type=checkbox]");
            foreach (Node checkbox in checkboxes)
            {
                Node parent = checkbox.ParentNode;
                parent.RemoveChild(checkbox);
            }

            document.Save(outputPath);
            Console.WriteLine("Conversion completed. Saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}