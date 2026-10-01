// Configure the validator to treat caption missing warnings as errors by adjusting severity settings.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";

            using (var document = new Aspose.Html.HTMLDocument(new MemoryStream(Encoding.UTF8.GetBytes(html)), ""))
            {
                var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                var validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
                else
                {
                    foreach (var ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (var techResult in ruleResult.Errors)
                            {
                                Console.WriteLine(techResult.Error.ErrorMessage);
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