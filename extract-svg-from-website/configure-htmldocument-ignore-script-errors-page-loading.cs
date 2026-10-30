// Configure HtmlDocument to ignore script errors during page loading.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.html";
                string outputPath = "output.html";

                if (!System.IO.File.Exists(inputPath))
                {
                    string htmlContent = "<!DOCTYPE html><html><head><script>throw new Error('Test error');</script></head><body><p>Hello World</p></body></html>";
                    System.IO.File.WriteAllText(inputPath, htmlContent);
                }

                Aspose.Html.Configuration config = new Aspose.Html.Configuration();
                config.Security |= Aspose.Html.Sandbox.Scripts;

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

                var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body")[0];
                body.Style.BackgroundColor = "lightgray";

                document.Save(outputPath);
                System.Console.WriteLine("Document saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}