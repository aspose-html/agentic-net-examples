// Validate that the document contains at least one heading to meet structural requirements.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with a heading
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Welcome</h1><p>Hello world.</p></body></html>";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Create accessibility validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Output validation errors if any
            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    if (!detail.Success)
                    {
                        Console.WriteLine(detail.Rule.Code + " - " + detail.Rule.Description);
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                        {
                            Aspose.Html.Accessibility.IError error = techResult.Error;
                            Console.WriteLine(error.ErrorMessage);
                            if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                            {
                                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                Console.WriteLine(element.OuterHTML);
                            }
                        }
                    }
                }
            }

            // Check for at least one heading element (h1-h6)
            bool hasHeading = false;
            for (int i = 1; i <= 6; i++)
            {
                string tag = "h" + i;
                if (document.GetElementsByTagName(tag).Length > 0)
                {
                    hasHeading = true;
                    break;
                }
            }

            if (hasHeading)
            {
                Console.WriteLine("Document contains at least one heading.");
            }
            else
            {
                Console.WriteLine("Document does not contain any heading.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}