// Load an HTML file from disk, change body background color, and overwrite the original file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><head><title>Sample</title></head><body>Hello World</body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)System.Linq.Enumerable.First(document.GetElementsByTagName("body"));
            body.Style.BackgroundColor = "lightblue";
            document.Save(inputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}