// Run default accessibility validation and direct console output to a debug logger for development monitoring.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with an image missing alt attribute (accessibility issue)
            string htmlContent = @"
                <html>
                    <head><title>Sample</title></head>
                    <body>
                        <h1>Welcome</h1>
                        <img src='sample.png'>
                        <a href='https://example.com'>Link</a>
                    </body>
                </html>";

            // 1. Basic validation – print success message or errors
            var webAccessibility1 = new Aspose.Html.Accessibility.WebAccessibility();
            var validator1 = webAccessibility1.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document1 = new Aspose.Html.HTMLDocument(htmlContent))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator1.Validate(document1);
                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
                else
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }

            // 2. Detailed error information – tag, attribute and message
            var webAccessibility2 = new Aspose.Html.Accessibility.WebAccessibility();
            var validator2 = webAccessibility2.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document2 = new Aspose.Html.HTMLDocument(htmlContent))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator2.Validate(document2);
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("alt") ?? "(none)";
                                    Console.WriteLine($"Tag: {tagName}, Attribute: alt, Value: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
            }

            // 3. Simple error messages for HTMLElement targets
            var webAccessibility3 = new Aspose.Html.Accessibility.WebAccessibility();
            var validator3 = webAccessibility3.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document3 = new Aspose.Html.HTMLDocument(htmlContent))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator3.Validate(document3);
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Console.WriteLine(techResult.Error.ErrorMessage);
                                }
                            }
                        }
                    }
                }
            }

            // 4. Retrieve principle, guideline, and criterion information
            var webAccessibility4 = new Aspose.Html.Accessibility.WebAccessibility();
            // Example codes – adjust as needed for real documents
            string principleCode = "1.1";      // Example principle code
            string guidelineCode = "1.1.1";    // Example guideline code
            string criterionCode = "1.1.1.1";  // Example criterion code

            Aspose.Html.Accessibility.Principle principle = webAccessibility4.Rules.GetPrinciple(principleCode);
            if (principle != null)
            {
                Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline(guidelineCode);
                if (guideline != null)
                {
                    Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion(criterionCode);
                    if (criterion != null)
                    {
                        Console.WriteLine($"{criterion.Code}:{criterion.Description} - {criterion.Level}");
                        foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                        {
                            Console.WriteLine($"{technique.Code}:{technique.Description}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}