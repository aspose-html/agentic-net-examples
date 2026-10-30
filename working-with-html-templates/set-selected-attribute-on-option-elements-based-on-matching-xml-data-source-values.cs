// Set the selected attribute on option elements based on matching values in the XML data source.

using System;
using System.Xml.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Sample XML data source
            string xmlData = @"<Dealers>
                                 <Dealer>
                                   <Id>1</Id>
                                   <SelectedOption>2</SelectedOption>
                                 </Dealer>
                               </Dealers>";

            // Sample HTML template with a select element
            string htmlTemplate = @"<html>
                                      <body>
                                        <select id='mySelect'>
                                          <option value='1'>One</option>
                                          <option value='2'>Two</option>
                                          <option value='3'>Three</option>
                                        </select>
                                      </body>
                                    </html>";

            // Parse XML and get the value to match
            XDocument xmlDoc = XDocument.Parse(xmlData);
            string selectedValue = xmlDoc.Root.Element("Dealer")?.Element("SelectedOption")?.Value ?? string.Empty;

            // Load HTML template (inline content) using two‑argument constructor
            Aspose.Html.HTMLDocument htmlDoc = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            // Find the select element by its id
            Aspose.Html.Dom.Element selectElement = htmlDoc.GetElementById("mySelect");
            if (selectElement == null)
                throw new InvalidOperationException("Select element not found.");

            // Get all option elements within the select
            Aspose.Html.Collections.HTMLCollection options = selectElement.GetElementsByTagName("option");

            // Set the selected attribute based on the XML value
            for (int i = 0; i < options.Length; i++)
            {
                Aspose.Html.Dom.Element option = (Aspose.Html.Dom.Element)options[i];
                string optionValue = option.GetAttribute("value");
                if (optionValue == selectedValue)
                {
                    option.SetAttribute("selected", "selected");
                }
                else
                {
                    option.RemoveAttribute("selected");
                }
            }

            // Save the resulting HTML to a file
            string outputPath = "output.html";
            htmlDoc.Save(outputPath);
            Console.WriteLine($"HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}