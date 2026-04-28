// Clone a navigation menu element and insert the clone at the end of the body.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

namespace CloneNavMenuExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new empty HTML document
                HTMLDocument document = new HTMLDocument();

                // Retrieve the <body> element
                HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();

                // Create a <nav> element (the navigation menu)
                HTMLElement nav = (HTMLElement)document.CreateElement("nav");
                // Add some placeholder content to the navigation menu
                Text navText = document.CreateTextNode("Original Menu");
                nav.AppendChild(navText);

                // Append the original navigation menu to the body
                body.AppendChild(nav);

                // Clone the navigation menu (deep clone to copy its children)
                Node clonedNav = nav.CloneNode(true);

                // Append the cloned navigation menu to the end of the body
                body.AppendChild(clonedNav);

                // Prepare save options (default options)
                HTMLSaveOptions options = new HTMLSaveOptions();

                // Save the modified document to a file
                string outputPath = "ClonedNavMenu.html";
                document.Save(outputPath, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}