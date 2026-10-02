// Verify that each <track> element includes a valid srclang attribute to meet accessibility standards.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body>" +
                                 "<video controls>" +
                                 "<source src=\"movie.mp4\" type=\"video/mp4\">" +
                                 "<track kind=\"subtitles\" src=\"subtitles_en.vtt\" srclang=\"en\" label=\"English\">" +
                                 "<track kind=\"subtitles\" src=\"subtitles_fr.vtt\" label=\"French\">" + // Missing srclang
                                 "</video>" +
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
                                    string srclangValue = element.GetAttribute("srclang");
                                    System.Console.WriteLine($"Tag: {tagName}, srclang: {srclangValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("All <track> elements have valid srclang attributes.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}