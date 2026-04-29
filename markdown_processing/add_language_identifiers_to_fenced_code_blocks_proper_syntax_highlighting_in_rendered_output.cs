// Add language identifiers to fenced code blocks to enable proper syntax highlighting in rendered output.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace AddLanguageIdentifierExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var document = new HTMLDocument();
                var pre = document.CreateElement("pre");
                var code = document.CreateElement("code");
                code.SetAttribute("class", "language-csharp");
                code.TextContent = "Console.WriteLine(\"Hello, World!\");";
                pre.AppendChild(code);
                document.Body.AppendChild(pre);
                document.Save("output.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}