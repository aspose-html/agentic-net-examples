// Instantiate HTMLDocument with a URL, append a script element, and prevent execution using sandboxing.

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                Aspose.Html.HTMLElement script = (Aspose.Html.HTMLElement)document.CreateElement("script");
                script.TextContent = "console.log('Hello from sandboxed script');";
                ((Aspose.Html.HTMLElement)document.Body).AppendChild(script);
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                System.Console.WriteLine(html);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}