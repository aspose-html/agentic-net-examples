// Load HTML content from a string and initialize an HTMLDocument with the configured Configuration.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration);
            string outerHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
            System.Console.WriteLine(outerHtml);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}