// Create a template string that includes a conditional class attribute based on user role.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML template with a checkbox input
            string htmlTemplate = "<!DOCTYPE html><html><body><input type=\"checkbox\" id=\"chk1\"/></body></html>";
            bool isChecked = true;
            string outputPath = "output.html";
            string imagePath = "output.png";

            // Load the template into a document
            var templateDocument = new Aspose.Html.HTMLDocument(htmlTemplate, "");

            // Prepare template conversion data
            var contentOptions = new Aspose.Html.Converters.TemplateContentOptions(htmlTemplate, Aspose.Html.Converters.TemplateContent.XML);
            var templateData = new Aspose.Html.Converters.TemplateData(contentOptions);
            var loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template (returns a new HTMLDocument)
            var resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(templateDocument, templateData, loadOptions);

            // Manipulate the input element
            var input = (Aspose.Html.HTMLInputElement)resultDocument.GetElementsByTagName("input")[0];
            input.Checked = isChecked;
            Console.WriteLine("Checked: " + input.Checked);

            // Save the modified HTML
            resultDocument.Save(outputPath);
            Console.WriteLine("HTML saved to " + outputPath);

            // Render the document to an image
            var imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            var imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, imagePath);
            resultDocument.RenderTo(imgDevice);
            Console.WriteLine("Image rendered to " + imagePath);

            // Accessibility checks (example strings; adjust as needed)
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var principle = webAccessibility.Rules.GetPrinciple("WCAG2AA");
            var guideline = principle?.GetGuideline("1.1.1");
            var criterion = guideline?.GetCriterion("1.1.1");
            if (criterion != null)
            {
                Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);
                foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                {
                    Console.WriteLine("{0}:{1}", technique.Code, technique.Description);
                }
            }

            // DOM manipulation example
            var domDocument = new Aspose.Html.HTMLDocument("<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>", "");
            var paragraph = (Aspose.Html.HTMLElement)domDocument.GetElementsByTagName("p")[0];
            paragraph.Style.Color = "aliceblue";

            // Add a style element
            var styleElement = (Aspose.Html.HTMLElement)domDocument.CreateElement("style");
            styleElement.TextContent = "p { font-weight: bold; }";
            domDocument.GetElementsByTagName("head")[0].AppendChild(styleElement);

            // Save the DOM-modified document
            domDocument.Save("dom_output.html");
            Console.WriteLine("DOM-modified HTML saved to dom_output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}