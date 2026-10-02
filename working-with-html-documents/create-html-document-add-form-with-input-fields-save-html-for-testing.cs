// Create an HTML document, add a form with input fields, and save as HTML for testing.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string outputPath = "output.html";

                using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument("<!DOCTYPE html><html><head><title>Form Example</title></head><body></body></html>", "about:blank"))
                {
                    Aspose.Html.HTMLElement form = (Aspose.Html.HTMLElement)doc.CreateElement("form");
                    form.SetAttribute("method", "post");
                    form.SetAttribute("action", "submit.html");

                    Aspose.Html.HTMLElement input1 = (Aspose.Html.HTMLElement)doc.CreateElement("input");
                    input1.SetAttribute("type", "text");
                    input1.SetAttribute("name", "username");
                    input1.SetAttribute("placeholder", "Enter username");

                    Aspose.Html.HTMLElement input2 = (Aspose.Html.HTMLElement)doc.CreateElement("input");
                    input2.SetAttribute("type", "password");
                    input2.SetAttribute("name", "password");
                    input2.SetAttribute("placeholder", "Enter password");

                    Aspose.Html.HTMLElement submit = (Aspose.Html.HTMLElement)doc.CreateElement("input");
                    submit.SetAttribute("type", "submit");
                    submit.SetAttribute("value", "Login");

                    form.AppendChild(input1);
                    form.AppendChild(input2);
                    form.AppendChild(submit);

                    Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)doc.GetElementsByTagName("body")[0];
                    body.AppendChild(form);

                    doc.Save(outputPath);
                }

                System.Console.WriteLine("HTML document saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}