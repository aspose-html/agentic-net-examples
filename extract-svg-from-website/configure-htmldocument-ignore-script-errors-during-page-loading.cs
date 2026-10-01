// Configure HtmlDocument to ignore script errors during page loading.

using System;

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
                string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title></head><body><script>throw new Error('test');</script><p>Hello World</p></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

            var bodyCollection = document.GetElementsByTagName("body");
            var body = (Aspose.Html.HTMLElement)bodyCollection[0];
            body.Style.BackgroundColor = "lightgray";

            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}