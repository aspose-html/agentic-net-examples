// Configure sandbox to limit script execution count, load a page with many scripts, and monitor limits.

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            string htmlContent = "<!DOCTYPE html><html><head>" +
                                 "<script>var a = 1;</script>" +
                                 "<script>var b = 2;</script>" +
                                 "<script>var c = 3;</script>" +
                                 "<script>var d = 4;</script>" +
                                 "<script>var e = 5;</script>" +
                                 "</head><body><h1>Hello World</h1></body></html>";

            string tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            System.IO.File.WriteAllText(tempFile, htmlContent);

            using (var document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                System.Console.WriteLine(text);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}