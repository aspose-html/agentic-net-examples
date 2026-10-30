// Retrieve the title element text from a loaded HTML document and store it in a variable.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
            {
                string title = document.Title;
                Console.WriteLine(title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}