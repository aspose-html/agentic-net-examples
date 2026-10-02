// Load HTML content from a string and initialize an HTMLDocument with the configured Configuration.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, config))
            {
                string outerHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine(outerHtml);

                string outputPath = "output.html";
                document.Save(outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}