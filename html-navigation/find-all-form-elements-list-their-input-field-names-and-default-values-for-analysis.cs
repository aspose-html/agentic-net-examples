// Find all form elements, list their input field names and default values for analysis.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"<!DOCTYPE html><html><body><form id='f1'><input type='text' name='username' value='john'><input type='password' name='pwd'><select name='country'><option value='us'>US</option><option value='ca' selected>Canada</option></select><textarea name='comments'>Default comment</textarea></form></body></html>";

            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var forms = document.QuerySelectorAll("form");

            foreach (Aspose.Html.HTMLElement form in forms)
            {
                var fields = form.QuerySelectorAll("input, select, textarea");
                foreach (Aspose.Html.HTMLElement field in fields)
                {
                    string name = field.GetAttribute("name");
                    string value = field.GetAttribute("value");
                    string tag = field.TagName.ToLowerInvariant();

                    if (tag == "select")
                    {
                        var selectedOption = field.QuerySelector("option[selected]");
                        if (selectedOption != null)
                        {
                            value = selectedOption.GetAttribute("value");
                        }
                    }
                    else if (tag == "textarea")
                    {
                        value = field.TextContent;
                    }

                    Console.WriteLine($"Field Name: {name}, Default Value: {value}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}