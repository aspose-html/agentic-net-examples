// Iterate AccessibilityRules.AdvisoryTechniques to list improvement suggestions for each identified issue.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a sample HTML file
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath,
                "<!DOCTYPE html><html><head><title>Test</title></head>" +
                "<body><img src=\"image.png\"><p>Hello World</p></body></html>");

            // 1. Detailed validation with element info
            Aspose.Html.Accessibility.WebAccessibility webAccessibility1 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator1 = webAccessibility1.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult1 = validator1.Validate(document1);
                if (!validationResult1.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult1.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("alt");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
            }

            // 2. Simple error messages
            Aspose.Html.Accessibility.WebAccessibility webAccessibility2 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator2 = webAccessibility2.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult2 = validator2.Validate(document2);
                if (!validationResult2.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult2.Details)
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

            // 3. Success / failure output
            Aspose.Html.Accessibility.WebAccessibility webAccessibility3 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator3 = webAccessibility3.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult3 = validator3.Validate(document3);
                if (validationResult3.Success)
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
                else
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult3.Details)
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

            // 4. Validation for a specific guideline
            Aspose.Html.Accessibility.WebAccessibility webAccessibility4 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.Principle principle4 = webAccessibility4.Rules.GetPrinciple("Perceivable");
            Aspose.Html.Accessibility.Guideline guideline4 = principle4.GetGuideline("Text Alternatives");
            Aspose.Html.Accessibility.AccessibilityValidator validator4 = webAccessibility4.CreateValidator(guideline4, Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document4 = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult4 = validator4.Validate(document4);
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult4.Details)
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

            // 5. List criterion and its sufficient techniques
            Aspose.Html.Accessibility.WebAccessibility webAccessibility5 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.Principle principle5 = webAccessibility5.Rules.GetPrinciple("Perceivable");
            Aspose.Html.Accessibility.Guideline guideline5 = principle5.GetGuideline("Text Alternatives");
            Aspose.Html.Accessibility.Criterion criterion5 = guideline5.GetCriterion("1.1.1");
            if (criterion5 != null)
            {
                Console.WriteLine($"{criterion5.Code}:{criterion5.Description} - {criterion5.Level}");
                foreach (Aspose.Html.Accessibility.IRule technique in criterion5.SufficientTechniques)
                {
                    Console.WriteLine($"{technique.Code}:{technique.Description}");
                }
            }
            else
            {
                Console.WriteLine("Criterion not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}