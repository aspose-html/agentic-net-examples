// Identify video elements lacking audio description tracks by filtering validation messages for description warnings.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><body>" +
                    "<video src='video1.mp4'></video>" +
                    "<video src='video2.mp4'><track kind='descriptions' src='desc.vtt'></track></video>" +
                    "</body></html>";

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                    Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

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
                                        if (techResult.Error.ErrorMessage != null && techResult.Error.ErrorMessage.IndexOf("description", StringComparison.OrdinalIgnoreCase) >= 0)
                                        {
                                            string src = element.GetAttribute("src");
                                            Console.WriteLine($"Video element missing audio description. Tag: {tagName}, src: {src}, Message: {techResult.Error.ErrorMessage}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No accessibility issues found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}