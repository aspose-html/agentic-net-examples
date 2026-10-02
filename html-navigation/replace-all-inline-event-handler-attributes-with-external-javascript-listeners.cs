// Replace all inline event handler attributes (e.g., onclick) with external JavaScript listeners.

using System;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><button onclick=\"alert('Clicked!')\">Click Me</button></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Find all elements with an inline onclick attribute
            var elements = document.QuerySelectorAll("[onclick]");

            StringBuilder scriptBuilder = new StringBuilder();

            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element el = (Aspose.Html.Dom.Element)elements[i];
                string onclickValue = el.GetAttribute("onclick");
                if (!string.IsNullOrEmpty(onclickValue))
                {
                    // Remove the inline attribute
                    el.RemoveAttribute("onclick");

                    // Ensure the element has an id
                    string id = el.GetAttribute("id");
                    if (string.IsNullOrEmpty(id))
                    {
                        id = "elem_" + i;
                        el.SetAttribute("id", id);
                    }

                    // Build JavaScript listener code
                    scriptBuilder.AppendLine($"document.getElementById('{id}').addEventListener('click', function(event){{ {onclickValue} }});");
                }
            }

            // Add a script element with the generated listeners
            if (scriptBuilder.Length > 0)
            {
                Aspose.Html.HTMLElement scriptElement = (Aspose.Html.HTMLElement)document.CreateElement("script");
                scriptElement.InnerHTML = scriptBuilder.ToString();
                if (document.Body != null)
                {
                    document.Body.AppendChild(scriptElement);
                }
                else if (document.DocumentElement != null)
                {
                    document.DocumentElement.AppendChild(scriptElement);
                }
            }

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Document processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}