// Set the checked attribute on a checkbox conditionally based on a boolean value in the data source.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlTemplate = "<!DOCTYPE html><html><body><input type='checkbox' id='myCheck'></body></html>";
            bool isChecked = true;
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");
            Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)document.GetElementsByTagName("input")[0];
            input.Checked = isChecked;
            document.Save(outputPath);

            Console.WriteLine("Checkbox checked state set to: " + input.Checked);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}