// Use a foreach directive {{#foreach item in collection}} to repeat a table row for each item.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Sample Table</title></head><body><table border=\"1\"><tr><th>Item</th></tr>{{#foreach item in collection}}<tr><td>{{item.text}}</td></tr>{{/foreach}}</table></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            document.Save("output.html");
            Console.WriteLine("HTML document saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}