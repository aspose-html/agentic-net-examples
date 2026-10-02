// Identify and list all form action URLs for backend endpoint mapping in the application.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = @"<html><body>" +
                          "<form action='https://example.com/api/submit1' method='post'></form>" +
                          "<form action='/local/submit2'></form>" +
                          "<form></form>" +
                          "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection forms = document.Forms;
                for (int i = 0; i < forms.Length; i++)
                {
                    Aspose.Html.HTMLFormElement form = forms[i] as Aspose.Html.HTMLFormElement;
                    if (form != null)
                    {
                        string action = form.Action;
                        if (!string.IsNullOrEmpty(action))
                        {
                            Console.WriteLine(action);
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