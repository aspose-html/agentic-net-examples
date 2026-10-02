// Toggle the checked state of task list items programmatically to reflect completion status.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlTemplate = "<!DOCTYPE html><html><body><ul><li><input type=\"checkbox\"/> Task 1</li><li><input type=\"checkbox\" checked/> Task 2</li></ul></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlTemplate, baseUri))
            {
                var inputs = document.GetElementsByTagName("input");
                for (int i = 0; i < inputs.Length; i++)
                {
                    Aspose.Html.HTMLInputElement input = inputs[i] as Aspose.Html.HTMLInputElement;
                    if (input != null)
                    {
                        string typeAttr = input.GetAttribute("type");
                        if (!string.IsNullOrEmpty(typeAttr) && typeAttr.Equals("checkbox", StringComparison.OrdinalIgnoreCase))
                        {
                            input.Checked = !input.Checked;
                        }
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Modified HTML saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}