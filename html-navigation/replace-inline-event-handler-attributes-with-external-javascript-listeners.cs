// Replace all inline event handler attributes (e.g., onclick) with external JavaScript listeners.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <button id=""btn1"" onclick=""alert('Button clicked!')"">Click Me</button>
    <div onclick=""console.log('Div clicked');"">Clickable Div</div>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Find all elements with an inline onclick attribute
            var elements = document.QuerySelectorAll("[onclick]");

            // Prepare JavaScript code that will be inserted into a <script> tag
            var scriptBuilder = new System.Text.StringBuilder();

            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element el = (Aspose.Html.Dom.Element)elements[i];
                string onclickValue = el.GetAttribute("onclick");

                if (!string.IsNullOrEmpty(onclickValue))
                {
                    // Remove the inline onclick attribute
                    el.RemoveAttribute("onclick");

                    // Ensure the element has an id attribute
                    string id = el.GetAttribute("id");
                    if (string.IsNullOrEmpty(id))
                    {
                        id = "elem_" + i;
                        el.SetAttribute("id", id);
                    }

                    // Append JavaScript listener code
                    scriptBuilder.AppendLine($"document.getElementById('{id}').addEventListener('click', function(event) {{ {onclickValue} }});");
                }
            }

            // If any listeners were added, create a <script> element and append it to the document
            if (scriptBuilder.Length > 0)
            {
                Aspose.Html.HTMLElement scriptElement = (Aspose.Html.HTMLElement)document.CreateElement("script");
                scriptElement.InnerHTML = scriptBuilder.ToString();
                document.Body.AppendChild(scriptElement);
            }

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Processing completed. Modified file saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}