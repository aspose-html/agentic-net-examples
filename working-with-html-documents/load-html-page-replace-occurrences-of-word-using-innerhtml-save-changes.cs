// Load an HTML page, replace all occurrences of a word using innerHTML, and save changes.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>Hello world! This is a sample. Hello world again.</body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                var bodyElements = document.GetElementsByTagName("body");
                foreach (Element element in bodyElements)
                {
                    var htmlElement = element as Aspose.Html.HTMLElement;
                    if (htmlElement != null)
                    {
                        string inner = htmlElement.InnerHTML;
                        inner = inner.Replace("Hello", "Hi");
                        htmlElement.InnerHTML = inner;
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Modified HTML saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}