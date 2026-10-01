// Filter errors by Target.TargetTypes to separate HTML element issues from CSS related problems.

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'><div><p>Hello</p></div></body></html>";

            // Initialize WebAccessibility
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Create a validator for all rules
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document from the string
            using (var document = new Aspose.Html.HTMLDocument(html))
            {
                // Perform validation
                var validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (var ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (var techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    var element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("alt");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }

                // Retrieve a specific principle and guideline, then validate against that guideline
                var principle = webAccessibility.Rules.GetPrinciple("Perceivable");
                var guideline = principle.GetGuideline("Text Alternatives");
                var guidelineValidator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);
                var guidelineResult = guidelineValidator.Validate(document);
                Console.WriteLine($"Guideline validation success: {guidelineResult.Success}");

                // Query selector example: set background color for all <p> elements
                var elements = document.QuerySelectorAll("p");
                foreach (Aspose.Html.HTMLElement element in elements)
                {
                    element.Style.BackgroundColor = "aliceblue";
                }

                // Save the modified document
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Modified document saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}