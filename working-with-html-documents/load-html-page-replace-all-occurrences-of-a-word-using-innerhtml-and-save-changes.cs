// Load an HTML page, replace all occurrences of a word using innerHTML, and save changes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Hello world! This is a sample. Hello world again.</p></body></html>";
            string outputPath = "output.html";

            // Load HTML from string
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Replace all occurrences of the word "Hello" with "Hi" using innerHTML
                var body = document.Body as Aspose.Html.HTMLElement;
                if (body != null)
                {
                    body.InnerHTML = body.InnerHTML.Replace("Hello", "Hi");
                }

                // Save the modified document
                document.Save(outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}