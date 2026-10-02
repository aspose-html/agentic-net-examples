// Extract CSRF token hidden input values from forms for security testing purposes.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"<html><body>
                <form>
                    <input type='hidden' name='csrf_token' value='abc123' />
                    <input type='hidden' name='csrf_param' value='def456' />
                    <input type='hidden' name='other' value='xyz' />
                </form>
            </body></html>";

            // Load HTML from string using two‑argument constructor (content, baseUri)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all input elements
            Aspose.Html.Collections.HTMLCollection inputElements = document.GetElementsByTagName("input");

            foreach (Aspose.Html.HTMLElement input in inputElements)
            {
                string type = input.GetAttribute("type");
                if (!string.IsNullOrEmpty(type) && type.Equals("hidden", StringComparison.OrdinalIgnoreCase))
                {
                    string name = input.GetAttribute("name");
                    if (!string.IsNullOrEmpty(name) && name.IndexOf("csrf", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string value = input.GetAttribute("value");
                        Console.WriteLine($"CSRF token found: name=\"{name}\", value=\"{value}\"");
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