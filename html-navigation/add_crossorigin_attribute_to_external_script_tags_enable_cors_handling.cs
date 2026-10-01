// Add a crossorigin attribute to external script tags to enable CORS handling.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><script src=\"https://example.com/lib.js\"></script></head><body></body></html>";
            string tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            System.IO.File.WriteAllText(tempFile, htmlContent);
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                Aspose.Html.Collections.HTMLCollection scriptElements = document.GetElementsByTagName("script");
                for (int i = 0; i < scriptElements.Length; i++)
                {
                    Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                    string src = scriptElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        scriptElement.SetAttribute("crossorigin", "anonymous");
                    }
                }
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                System.Console.WriteLine(output);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}