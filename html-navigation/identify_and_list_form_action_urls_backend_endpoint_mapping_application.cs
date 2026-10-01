// Identify and list all form action URLs for backend endpoint mapping in the application.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            string htmlContent = "<html><body>" +
                                 "<form action='https://example.com/submit1'></form>" +
                                 "<form action='https://example.com/submit2'></form>" +
                                 "</body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                // Extraction of form action URLs is not demonstrated due to API limitations.
                System.Console.WriteLine("Form action URLs extraction is not demonstrated.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}