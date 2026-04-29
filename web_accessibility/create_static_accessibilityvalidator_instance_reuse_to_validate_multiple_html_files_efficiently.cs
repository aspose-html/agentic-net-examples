// Create a static AccessibilityValidator instance and reuse it to validate multiple HTML files efficiently.

using System;

class Program
{
    private static readonly Aspose.Html.Accessibility.AccessibilityValidator validator;

    static Program()
    {
        Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
        validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
    }

    static void Main()
    {
        try
        {
            string[] htmlFiles = { "file1.html", "file2.html", "file3.html" };

            foreach (string path in htmlFiles)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(path))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                    if (validationResult.Success)
                    {
                        Console.WriteLine($"[PASS] {path}");
                    }
                    else
                    {
                        Console.WriteLine($"[FAIL] {path}");
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
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}