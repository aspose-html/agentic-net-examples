// Find all form elements, list their input field names and default values for analysis.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file with forms
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Sample Form</title></head>
<body>
    <form id='form1'>
        <input type='text' name='firstName' value='John' />
        <input type='text' name='lastName' value='Doe' />
        <input type='email' name='email' value='john.doe@example.com' />
    </form>
    <form id='form2'>
        <input type='checkbox' name='subscribe' value='yes' />
        <input type='hidden' name='token' value='abc123' />
    </form>
</body>
</html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all form elements
            HTMLCollection forms = document.GetElementsByTagName("form");
            for (int i = 0; i < forms.Length; i++)
            {
                Element form = (Element)forms[i];
                Console.WriteLine($"Form #{i + 1}:");

                // Get all input elements within the form
                HTMLCollection inputs = form.GetElementsByTagName("input");
                for (int j = 0; j < inputs.Length; j++)
                {
                    Element input = (Element)inputs[j];
                    string name = input.GetAttribute("name");
                    string value = input.GetAttribute("value");
                    Console.WriteLine($"  Input Name: {name ?? "(no name)"}; Default Value: {value ?? "(no value)"}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}