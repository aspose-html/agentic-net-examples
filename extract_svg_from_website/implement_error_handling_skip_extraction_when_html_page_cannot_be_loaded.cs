// Implement error handling to skip extraction when the HTML page cannot be loaded.

using System;
using Aspose.Html;

namespace HtmlExtraction
{
    class Program
    {
        static void Main()
        {
            string htmlPath = "example.html";
            try
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.HTMLElement body = document.Body;
                string content = body?.TextContent;
                Console.WriteLine(content);
            }
            catch (Exception)
            {
            }
        }
    }
}