// Write a method that returns warning counts grouped by each target element type for analysis.

namespace AsposeHtmlAccessibilityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'><a href='#'>Link</a></body></html>";
                var counts = GetWarningCounts(html);
                foreach (var kvp in counts)
                {
                    System.Console.WriteLine($"Tag: {kvp.Key}, Warning Count: {kvp.Value}");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static System.Collections.Generic.Dictionary<string, int> GetWarningCounts(string htmlContent)
        {
            var result = new System.Collections.Generic.Dictionary<string, int>();
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
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
                                    var tagName = element.TagName;
                                    if (result.ContainsKey(tagName))
                                    {
                                        result[tagName] = result[tagName] + 1;
                                    }
                                    else
                                    {
                                        result[tagName] = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}