// Load an HTML file, replace all double quotes in attribute values with single quotes, and save.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            var elements = document.GetElementsByTagName("*");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                var attrs = element.Attributes;
                for (int i = 0; i < attrs.Length; i++)
                {
                    var attr = (Attr)attrs[i];
                    string name = attr.Name;
                    string value = attr.Value;
                    if (!string.IsNullOrEmpty(value) && value.Contains("\""))
                    {
                        string newValue = value.Replace("\"", "'");
                        element.SetAttribute(name, newValue);
                    }
                }
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}