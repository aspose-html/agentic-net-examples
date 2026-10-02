// Create an HTML document, add a meta robots tag with noindex, and verify search engine directives.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><meta name=\"robots\" content=\"noindex\"></head><body><p>Hello</p></body></html>";
                string tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
                System.IO.File.WriteAllText(tempFile, htmlContent);

                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                configuration.Security |= Aspose.Html.Sandbox.Scripts;

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
                {
                    // Retrieve meta robots tag
                    Aspose.Html.Collections.HTMLCollection metas = document.GetElementsByTagName("meta");
                    for (int i = 0; i < metas.Length; i++)
                    {
                        Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)metas[i];
                        string nameAttr = element.GetAttribute("name");
                        if (nameAttr != null && nameAttr.Equals("robots", System.StringComparison.OrdinalIgnoreCase))
                        {
                            string contentAttr = element.GetAttribute("content");
                            System.Console.WriteLine($"Meta robots tag found: content=\"{contentAttr}\"");
                        }
                    }

                    // Validate accessibility (including search engine directives)
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
                                        string attributeValue = element.GetAttribute("content");
                                        System.Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}