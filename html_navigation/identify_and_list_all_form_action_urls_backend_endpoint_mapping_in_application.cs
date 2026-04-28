// Identify and list all form action URLs for backend endpoint mapping in the application.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Forms;

namespace FormActionLister
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    foreach (HTMLFormElement form in document.Forms)
                    {
                        Console.WriteLine(form.Action);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}