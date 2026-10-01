// Retrieve the title element text from a loaded HTML document and store it in a variable.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "sample.html";

            if (!System.IO.File.Exists(url))
            {
                System.IO.File.WriteAllText(url, "<html><head><title>Sample Title</title></head><body></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            string title = document.Title;
            System.Console.WriteLine(title);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}