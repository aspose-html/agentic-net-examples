// Find all form elements, list their input field names and default values for analysis.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body>" +
                                 "<form>" +
                                 "<input type='text' name='username' value='john'>" +
                                 "<input type='password' name='pwd' value=''>" +
                                 "<textarea name='bio'>Default bio</textarea>" +
                                 "</form>" +
                                 "</body></html>";

            // Load HTML from inline string (use two-argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all form elements
            Aspose.Html.Collections.NodeList forms = document.QuerySelectorAll("form");
            foreach (Aspose.Html.Dom.Node formNode in forms)
            {
                Aspose.Html.HTMLElement form = formNode as Aspose.Html.HTMLElement;
                if (form == null) continue;

                // Select input, select, and textarea elements within the form
                Aspose.Html.Collections.NodeList fields = form.QuerySelectorAll("input, select, textarea");
                foreach (Aspose.Html.Dom.Node fieldNode in fields)
                {
                    Aspose.Html.HTMLElement field = fieldNode as Aspose.Html.HTMLElement;
                    if (field == null) continue;

                    string name = field.GetAttribute("name");
                    string value = field.GetAttribute("value");

                    // For textarea, the default value is its inner text if 'value' attribute is missing
                    if (string.IsNullOrEmpty(value) && field.TagName.Equals("textarea", StringComparison.OrdinalIgnoreCase))
                    {
                        value = field.TextContent;
                    }

                    Console.WriteLine($"Field Name: {name ?? "(none)"}; Default Value: {value ?? "(none)"}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}