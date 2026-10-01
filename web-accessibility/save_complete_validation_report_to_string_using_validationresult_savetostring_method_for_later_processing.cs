// Save the complete validation report to a string using ValidationResult.SaveToString method for later processing.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><input type='text' id='name'></body></html>";
            string baseUri = "http://example.com/";

            // 1. Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // 2. Perform accessibility validation
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(
                webAccessibility.Rules.GetPrinciple("WCAG2AA").GetGuideline("1.1.1"),
                Aspose.Html.Accessibility.ValidationBuilder.All);
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Output validation result as XML string
            string validationXml = validationResult.SaveToString();
            Console.WriteLine("Accessibility Validation Result (XML):");
            Console.WriteLine(validationXml);

            if (!validationResult.Success)
            {
                Console.WriteLine("Validation reported errors.");
            }
            else
            {
                Console.WriteLine("Validation succeeded.");
            }

            // 3. Modify input element value
            Aspose.Html.HTMLDocument docForSave = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            Aspose.Html.Collections.HTMLCollection inputElements = docForSave.GetElementsByTagName("input");
            if (inputElements.Length > 0)
            {
                Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
                input.Value = "John Doe";
            }

            // 4. Save modified HTML with options
            string outputHtmlPath = "output.html";
            Aspose.Html.Saving.HTMLSaveOptions htmlSaveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            htmlSaveOptions.SerializeInputValue = true;
            docForSave.Save(outputHtmlPath, htmlSaveOptions);
            Console.WriteLine($"Modified HTML saved to '{outputHtmlPath}'.");

            // 5. Convert HTML to MHTML
            string outputMhtmlPath = "output.mhtml";
            Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, mhtmlOptions, outputMhtmlPath);
            Console.WriteLine($"MHTML file saved to '{outputMhtmlPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}