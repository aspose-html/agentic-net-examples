// Filter warnings by specific RuleId values to focus on particular accessibility techniques.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a sample HTML file
            string htmlFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(htmlFilePath,
@"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <img src=""image.jpg"" alt="""">
    <h1>Welcome</h1>
</body>
</html>");

            // 1. Basic validation and error messages
            Aspose.Html.Accessibility.WebAccessibility webAccessibility1 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator1 = webAccessibility1.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(htmlFilePath))
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
                                    Console.WriteLine(techResult.Error.ErrorMessage);
                                }
                            }
                        }
                    }
                }
            }

            // 2. Retrieve principle, guideline, criterion information
            Aspose.Html.Accessibility.WebAccessibility webAccessibility2 = new Aspose.Html.Accessibility.WebAccessibility();
            // Example codes – replace with real codes if needed
            Aspose.Html.Accessibility.Principle principle = webAccessibility2.Rules.GetPrinciple("1.1");
            if (principle != null)
            {
                Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("1.1.1");
                if (guideline != null)
                {
                    Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion("1.1.1.1");
                    if (criterion != null)
                    {
                        Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);
                        foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                        {
                            Console.WriteLine("{0}:{1}", technique.Code, technique.Description);
                        }
                    }
                }
            }

            // 3. Validation with element details (tag, attribute)
            Aspose.Html.Accessibility.WebAccessibility webAccessibility3 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator3 = webAccessibility3.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult3 = validator3.Validate(document3);
                if (!validationResult3.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult3.Details)
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

            // 4. Simple success/failure message
            Aspose.Html.Accessibility.WebAccessibility webAccessibility4 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator4 = webAccessibility4.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document4 = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult4 = validator4.Validate(document4);
                if (validationResult4.Success)
                {
                    Console.WriteLine("Document passed all accessibility checks.");
                }
                else
                {
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
            }

            // Clean up temporary file
            if (File.Exists(htmlFilePath))
            {
                File.Delete(htmlFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}