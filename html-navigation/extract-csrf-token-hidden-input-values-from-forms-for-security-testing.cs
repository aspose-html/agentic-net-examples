// Extract CSRF token hidden input values from forms for security testing purposes.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><form><input type='hidden' name='csrf_token' value='abc123'/><input type='text' name='user'/></form></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.HTMLCollection inputs = document.GetElementsByTagName("input");
            for (int i = 0; i < inputs.Length; i++)
            {
                Aspose.Html.HTMLElement input = (Aspose.Html.HTMLElement)inputs[i];
                string type = input.GetAttribute("type");
                if (type != null && type.Equals("hidden", StringComparison.OrdinalIgnoreCase))
                {
                    string name = input.GetAttribute("name");
                    if (name != null && name.IndexOf("csrf", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string value = input.GetAttribute("value");
                        Console.WriteLine($"Found CSRF token: name='{name}', value='{value}'");
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