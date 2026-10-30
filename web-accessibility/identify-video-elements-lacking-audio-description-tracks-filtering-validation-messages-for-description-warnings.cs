// Identify video elements lacking audio description tracks by filtering validation messages for description warnings.

using System;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a video element lacking audio description
            string htmlContent = @"
                <html>
                    <body>
                        <video src='sample.mp4' controls></video>
                        <video src='sample-with-desc.mp4' controls>
                            <track kind='descriptions' src='desc.vtt' srclang='en' label='English Descriptions'>
                        </video>
                    </body>
                </html>";
            // Load HTML from string (inline content)
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Create validator with all rules
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    HTMLElement element = (HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string src = element.GetAttribute("src");

                                    // Filter for audio description warnings
                                    if (techResult.Error.ErrorMessage != null &&
                                        techResult.Error.ErrorMessage.IndexOf("audio description", StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        Console.WriteLine($"Tag: {tagName}, Src: {src}, Message: {techResult.Error.ErrorMessage}");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No accessibility issues detected.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}