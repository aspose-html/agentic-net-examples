// Identify and list all form action URLs for backend endpoint mapping in the application.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<form action='https://example.com/submit1'></form>" +
                                 "<form action='https://example.com/submit2'></form>" +
                                 "<form></form>" + // form without action
                                 "</body></html>";

            // Load HTML from string with a dummy base URI
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Get all <form> elements
                Aspose.Html.Collections.HTMLCollection forms = document.GetElementsByTagName("form");

                for (int i = 0; i < forms.Length; i++)
                {
                    Aspose.Html.HTMLElement formElement = forms[i] as Aspose.Html.HTMLElement;
                    if (formElement != null)
                    {
                        string actionUrl = formElement.GetAttribute("action");
                        if (!string.IsNullOrEmpty(actionUrl))
                        {
                            Console.WriteLine(actionUrl);
                        }
                        else
                        {
                            Console.WriteLine("[No action attribute]");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}