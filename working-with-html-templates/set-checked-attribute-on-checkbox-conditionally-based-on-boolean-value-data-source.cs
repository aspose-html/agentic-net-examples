// Set the checked attribute on a checkbox conditionally based on a boolean value in the data source.

class Program
{
    static void Main()
    {
        try
        {
            string htmlTemplate = "<!DOCTYPE html><html><body><input type=\"checkbox\" id=\"myCheck\"/></body></html>";
            bool isChecked = true;
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument templateDocument = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            Aspose.Html.Collections.HTMLCollection inputs = templateDocument.GetElementsByTagName("input");
            if (inputs.Length > 0)
            {
                Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputs[0];
                input.Checked = isChecked;
            }

            templateDocument.Save(outputPath);
            System.Console.WriteLine("Document saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}